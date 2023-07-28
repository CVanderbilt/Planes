using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Pair
{
	public int num;
	public ShopItem ab;

	public Pair(ShopItem item, int amount)
	{
		num = amount;
		ab = item;
	}
}

public class MetaPlayer : MonoBehaviour
{
	//Tendrá una lista de aviones con uno equipado(el equipado se usará al definir al player de dentro de cada escena jugable)
	//	este avión tendrá un inventario de habilidades equipadas, el jugador lo podrá modificar en el hangar?

	//Tendrá un array de pares habilidad-cantidad, en el que estarán todas las habilidades representadas y que cantidad posee
	//	la cantidad se podrá ver en la tienda(más adelante) y en el hangar

	//temporal
	//	realmente habrá que sacar las habilidades de un array/lista de habilidades definido en otro lao
	//public Ability ab1;
	//public Ability ab2;
	//temporal
	public Pair[] inventoryArray;
	public List<Pair> inventoryList;
	public int money;
	public TextMeshProUGUI moneyTxt;

	
	//abArray[0] = new Pair();
	/*abArray[0].ab = ab1;
	abArray[0].amount = 0;

	abArray[1].ab = ab2;
	abArray[1].amount = 0;*/


	//A lo mejor una lista de GameObjects para llevar la cuenta de otros objetos especiales que habrá comprado

    // Start is called before the first frame update
    void Start()
    {
        //abArray = new Pair[2];
    	moneyTxt.text = "Money: " + money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IncreaseAbility(string name)
    {
		foreach (Pair p in inventoryArray)
		{
			if (p.ab.GetName() == name)
			{
				p.num += 1;
				return true;
			}
		}
		return false;
    }

    public void AddItem(ShopItem it)
    {
    	foreach (Pair p in inventoryList)
    	{
    		if (p.ab.GetName() == it.GetName())
    		{
    			p.num += 1;
    			return ;
    		}
    	}
    	inventoryList.Add(new Pair(it, 1));
    }

    public int GetMoney()
    {
    	return money;
    }

    public void SetMoney(int m)
    {
    	money = m;
    	moneyTxt.text = "Money: " + money;
    }
}
