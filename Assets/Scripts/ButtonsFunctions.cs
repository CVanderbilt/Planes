using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    //Main menu
    public void Play()
    {
    	SceneManager.LoadScene("SampleLevel");
    }

    public void Restart()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
    	SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {

    }

    //General
    public void CloseTab() //Solo funciona si este script es child del panel a cerrar
    {
    	transform.parent.gameObject.SetActive(false);
    }

    //Map menu
    public void Purchase()
    {
    	ShopItem item = GetComponent<ShopButton>().GetItem();
    	MetaPlayer p = FindObjectOfType<MetaPlayer>();
    	if (p != null && item != null)
    	{
    		int r = p.GetMoney() - item.GetPrice();
    		if (r >= 0)
    		{
    			//if (p.IncreaseAbility(item.GetName()))
    			p.SetMoney(r);
    			p.AddItem(item);
    		}
    		//else una animacion + sonido que indique que no tiene pasta
    	}
    }

    public void ToggleShop()
    {
    	MapMenu m = FindObjectOfType<MapMenu>();

    	if (m != null)
    		m.ToggleShop();
    }

    public void ToggleInventory()
    {
    	MapMenu m = FindObjectOfType<MapMenu>();
    	if (m != null)
    		m.ToggleInventory();
    }
}
