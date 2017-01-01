using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class FullZakaz : MonoBehaviour {

	public Text ID; 
    public Text Price;
	public Text Mass;
	public Text Time; 
	public Text AddresCount;

	public Text Point;
	public Text Description;
	//public Text ArriveDay;
	public Text DeliverTime; 
	public Text Phone;
	public Text ContactFace; 
	//public Text PointMoney;

	public Dropdown drop;

	private string id;
	private string mass;
	private string price;
	private string time;

	private string addresCount;

	//public string[] arriveDay = new string[10];
	public string[] deliverTime = new string[10]; 
	public string[] arriveTime = new string[10]; 
	public string[] phone = new string[10];
	public string[] description = new string[10];
	public string[] contactFace = new string[10]; 
	public string[] point = new string[10];
	//public string[] pointMoney = new string[10]; 

	 void Start ()
	{
		drop.options.Clear ();
		ID.text = "Заказ №" + PlayerPrefs.GetString ("ID");	
		Mass.text = PlayerPrefs.GetString ("MASS");
		Price.text = PlayerPrefs.GetString ("PRISE");
		Time.text = PlayerPrefs.GetString ("TIME");
		AddresCount.text = PlayerPrefs.GetString ("ADDRESCOUNT");
		int count = PlayerPrefs.GetInt ("POINTS");
		for (int i = 0; i < count; i++)
		{
			point[i] = PlayerPrefs.GetString ("POINT"+i);
			description[i] = PlayerPrefs.GetString ("DESCRIPTION"+i);
			deliverTime[i] = PlayerPrefs.GetString ("DELIVERTIME"+i);
			arriveTime[i] = PlayerPrefs.GetString ("ARRIVETIME"+i);
			//arriveDay[i] = PlayerPrefs.GetString ("ARRIVEDAY"+i);
			phone[i] = PlayerPrefs.GetString ("PHONE"+i);
			contactFace[i] = PlayerPrefs.GetString ("CONTACTFACE"+i);
			//pointMoney[i] = PlayerPrefs.GetString ("POINTMONEY"+i);
			Dropdown.OptionData items = new Dropdown.OptionData ();
			items.text = "Адрес №"+(i+1)+" :"+point[i];
			drop.options.Add(items);

		}

	}

	void Update()
	{
		Point.text=point[drop.value];
		Description.text=description[drop.value];
		//ArriveDay.text=arriveDay[drop.value];
		DeliverTime.text ="Прибыть С: "+arriveTime[drop.value]+" До: "+deliverTime[drop.value];
		Phone.text="Телефон для связи: "+phone[drop.value];
		ContactFace.text =contactFace[drop.value];
		//PointMoney.text=pointMoney[drop.value];
	}
}


