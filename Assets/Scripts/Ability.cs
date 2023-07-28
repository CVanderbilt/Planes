using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ShopItem
{
	//public int maxUses;
	public int usesLeft;
	//public int price;
	protected string abName;

    public abstract void ActivateAbility();
    public abstract void SetUses(int n);
    //public abstract string GetName();

    public int GetUses()
    {
    	return usesLeft;
    }

    /*public override int GetPrice()
    {
    	return price;
    }

    public override Sprite GetImage()
    {
    	return image;
    }*/

}

/*public abstract class Ability : MonoBehaviour
{
	//public int maxUses;
	public int usesLeft;
	public int price;
	protected string abName;

    public abstract void ActivateAbility();
    public abstract void SetUses(int n);
    public abstract string GetName();

    public int GetUses()
    {
    	return usesLeft;
    }

    public int GetPrice()
    {
    	return price;
    }

}*/