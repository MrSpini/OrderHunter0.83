using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class SampleButton : MonoBehaviour 
{ 
	public Button buttonComponent; 
	public Text nameLabel; 
	public Image iconImage; 
	public Text priceText; 
	public Image MetroIcos; 
	public Text Times; 
	public Text MetroOne, MetroTwo; 
	public Text Address; 
	private Item item; 
	private ShopScrollList scrollList; 



	void Start () 
    { 
        buttonComponent.onClick.AddListener(HandleClick);
    }

   
	ShopScrollList SSl = new ShopScrollList(); 

	public void Setup(Item currentItem, ShopScrollList currentScrollList) 
	{ 
		item = currentItem; 
		nameLabel.text = item.Mass.ToString(); 
		iconImage.sprite = item.IconCompany; 
		MetroIcos.sprite = item.MetroIco; 
		priceText.text = item.Price; 
		Address.text = item.AddresCount; 
		Times.text = item.Time; 
		scrollList = currentScrollList; 

		MetroOne.text = item.Point[0]; 
		MetroTwo.text = item.Point[1]; 
	} 

    public void HandleClick()
    {
        scrollList.TryTransferItemToOtherShop(item);
    }

}


