using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using WebSocketSharp;
using LitJson;




[System.Serializable]

public class Item 
{ 
	public string ID; 
	public string SourceDay,Source_City; 
	public string OfferMode; 
	public string DeliveryType; 
	public string ObjectName; 
	public string Loading; 
	public string Mass; 

	public int Points;

	public string[] ArriveDay= new string[10];
	public string[] DeliverTime= new string[10]; 
	public string[] ArriveTime =new string[10]; 

	public string[] Phone =new string[10];
	public string[] Description= new string[10];
	public string[] ContactFace= new string[10]; 
	public string[] Point =new string[10];
	public string[] PointMoney= new string[10]; 

	public Sprite IconCompany,MetroIco; 
	public string Price; 
	public string MetroIn; 
	public string Time; 
	public string AddresCount; 
}

public class ShopScrollList : MonoBehaviour 
{
	int r=0;
	string json;
	string json1;
    private JsonData itemData;
    public List<Item> itemList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    public Scrollbar ScrollbarVertical;
    public GameObject Content;

    public string alltime, source_time_from, source_time_to; 

    void Start()
    {
		
		ConnctSocket();
		RefreshDisplay ();
    }

    void Update () 
    {   
         if (ScrollbarVertical.value <= 0 )
        {
            Content.GetComponent<RectTransform>().localPosition = new Vector2(this.transform.localPosition.x, this.transform.localPosition.y - 10);
        }

        if (Content.GetComponent<RectTransform>().localPosition.y <= -55)
        {   
            Content.GetComponent<RectTransform>().localPosition = new Vector2(this.transform.localPosition.x, 0);

			RefreshDisplay ();
			ConnctSocket();
        }
	}

    public void ConnctSocket()
	{  
		WebSocket ws = new WebSocket ("ws://app-labs-crawlers.ru:9090");
 
		string name = (string)PlayerPrefs.GetString ("Set-cookie");
		ws.SetCookie (new WebSocketSharp.Net.Cookie ("laravel_session", name));
		print ("connect");

		ws.OnMessage += (sender, e) => {      
			json = e.Data;
		
			print ("1" + json.ToString ());
			itemData = JsonMapper.ToObject (json);

			int count = itemData ["data"].Count; 

			for (int i = 0; i < count; i++) { 
				Item a = new Item ();
                
                a.ID = itemData ["data"] [i] ["id"].ToString (); 
				a.SourceDay = itemData ["data"] [i] ["source_day"].ToString (); 
				a.Source_City = itemData ["data"] [i] ["source_city"].ToString (); 
				a.OfferMode = itemData ["data"] [i] ["offer_mode"].ToString (); 
				a.DeliveryType = itemData ["data"] [i] ["delivery_type"].ToString ();
                a.ObjectName = itemData ["data"] [i] ["object_name"].ToString (); 
				a.Loading = itemData ["data"] [i] ["loading"].ToString (); 
				a.Points = itemData ["data"] [i] ["points_data"].Count;
				for (int j = 0; j < itemData ["data"] [i] ["points_data"].Count; j++) {
					a.Point [j] = itemData ["data"] [i] ["points_data"] [j] ["point"].ToString (); 
					a.ArriveDay [j] = itemData ["data"] [i] ["points_data"] [j] ["arrive_day"].ToString (); 
					a.ArriveTime [j] = itemData ["data"] [i] ["points_data"] [j] ["arrive_time"].ToString (); 
					a.DeliverTime [j] = itemData ["data"] [i] ["points_data"] [j] ["deliver_time"].ToString ();
					a.Phone [j] = itemData ["data"] [i] ["points_data"] [j] ["phone"].ToString (); 
					a.Description [j] = itemData ["data"] [i] ["points_data"] [j] ["description"].ToString (); 
					a.ContactFace [j] = itemData ["data"] [i] ["points_data"] [j] ["contact_face"].ToString (); 
					a.PointMoney [j] = itemData ["data"] [i] ["points_data"] [j] ["point_money"].ToString (); 
				}
				a.Mass = itemData ["data"] [i] ["object_weight"].ToString () + "кг"; 
				source_time_from = itemData ["data"] [i] ["source_time_from"].ToString (); 
				source_time_to = itemData ["data"] [i] ["source_time_to"].ToString (); 
				a.Price = itemData ["data"] [i] ["total_cost"].ToString () + "₽"; 
				alltime = "Прибыть с " + source_time_from + "до " + source_time_to; 
				a.Time = alltime; 
				a.AddresCount = "Адресов: " + itemData ["data"] [i] ["points_data"].Count.ToString (); 
				itemList.Add (a); 
			}
		};
		PlayerPrefs.SetString ("json", json);
		ws.Connect();
		
    }

    void RefreshDisplay()
    {
        RemoveButtons ();
        AddButtons ();
    }

    public void RemoveButtons()
    {
        while (contentPanel.childCount > 0) 
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void TryTransferItemToOtherShop(Item item)
    {   
		PlayerPrefs.SetString ("ID", item.ID.ToString ());
		PlayerPrefs.SetString ("MASS", item.Mass.ToString ());
		PlayerPrefs.SetString ("PRISE", item.Price.ToString ());
		PlayerPrefs.SetString ("TIME", item.Time.ToString ());
		PlayerPrefs.SetString ("ADDRESCOUNT", item.AddresCount.ToString ());

		PlayerPrefs.SetInt ("POINTS", item.Points);
		for (int i = 0; i < item.Points; i++)
		{
			PlayerPrefs.SetString ("POINT"+i, item.Point [i].ToString ());
			PlayerPrefs.SetString ("DESCRIPTION"+i, item.Description [i].ToString ());
			PlayerPrefs.SetString ("DELIVERTIME"+i, item.DeliverTime [i].ToString ());
			PlayerPrefs.SetString ("ARRIVETIME"+i, item.ArriveTime [i].ToString ());
			PlayerPrefs.SetString ("PHONE"+i, item.Phone [i].ToString ());
			PlayerPrefs.SetString ("CONTACTFACE"+i, item.ContactFace [i].ToString ());
			PlayerPrefs.SetString ("POINTMONEY"+i, item.PointMoney [i].ToString ());
		}

        SceneManager.LoadScene("zakaz");
    }

    public void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++) 
		{
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);
            newButton.transform.localScale = new Vector3(1,1,1);
            newButton.GetComponent<RectTransform>().localPosition = new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,1);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
			sampleButton.Setup(itemList[i], this);
        }
    }

	public void OnMouseDown()
	{
		print (itemList[0].ID);
	}
}