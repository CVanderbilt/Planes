using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItem : MonoBehaviour
{
	//public Button button;
	public Sprite image;
	public int price;
	//public GameObject objToBuy;
	//public string type;

	/*public Sprite GetImage()
	{
		return Image1;
	}*/

	/*public string GetName()
	{
		if (objToBuy != null)
		{
			Ability ab = objToBuy.GetComponent<Ability>();
			if (ab != null)
				return (ab.GetName());
			//Repite esto con el resto de tipos que puede haber en la tienda 
		}
		return ("Empty");
	}*/

	public Sprite GetImage()
	{
		return image;
	}
	public  int GetPrice()
	{
		return price;
	}
	
	public abstract string GetName();
	/*public int GetPrice()
	{
		if (objToBuy != null)
		{
			Ability ab = objToBuy.GetComponent<Ability>();
			if (ab != null)
				return (ab.GetPrice());
			//Repite esto con el resto de tipos que puede haber en la tienda
		}
		return (0);
	}

	public GameObject GetObj()
	{
		return objToBuy;
	}*/
}
