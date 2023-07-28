using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlane : ShopItem
{
	public string planeName;

	public int space;

	public float vSpeed;
	public float hSpeed;
	public float bulletSpeed;

	public float vulnerableTime = 1.5f;
    public float invulnerableTime = 0.5f;
    public int lifes = 5;

    public GameObject bullet;
    public GameObject explosion;

    public float frequency;
	
	//Puede tener más variables que lo definan (distintas compatibilidades con habilidades, más vida, más velocidad de recuperación...)

	public List<Pair> inventoryList; //cuidado con solo llenarlo de habilidades
	
	public int availableSpace;
	public int usedSpace = 0;

    public override string GetName()
    {
    	return planeName;
    }

    public int Add(Ability ab, int num)
    {
    	//Añade (num unidades) la habilidad a su inventario si puede, devuelve el numero de habilidades aumentado
    	// si num > que el espacio restante se llena al tope
    	// si la abilidad no estaba en la lista la añade con num = 1
    	int ret = num <= availableSpace - usedSpace ? num : availableSpace - usedSpace;

    	if (ret <= 0)
    		return 0;

    	foreach (Pair a in inventoryList) //La busca y si la encuentra la añade
    	{
    		if (a.ab.GetName() == ab.GetName())
    		{
    			usedSpace += ret;
    			a.num += ret;
    			return ret; //ya ha encontrado la habilidad y la ha aumentado devuelve la cantidad aumentada
    		}
    	}
    	//si sale es porque no lo ha encontrado así q lo añade manualmente
    	inventoryList.Add(new Pair(ab, ret));
    	return (ret);
    }

    public int Remove(Ability ab, int num)
    {
    	//Lo contrari a Add, devuelve el numero de usos retirados de la habilidad ab
    	// 0 si no había(Cuando llega a 0 también quita la habilidad de la lista)
    	// si num > los usos que tenía los quita todos y devuelve el numero quitado
    	int ret = 0;
    	int left;

    	foreach (Pair a in inventoryList)
    	{
    		if (a.ab.GetName() == ab.GetName())
    		{
    			left = a.num - num;
    			ret = a.num >= num ? num : a.num;
    			a.num = left;
    			if (a.num <= 0)
    				inventoryList.Remove(a);
    			break ;
    		}
    	}
    	return (ret);
    }
}
