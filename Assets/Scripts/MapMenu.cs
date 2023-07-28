using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject shop;
	public GameObject inventory;

    void Start()
    {
        //shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShop()
    {
    	bool b = shop.activeInHierarchy;

    	shop.SetActive(!b);
    }

    public void ToggleInventory()
    {
    	bool b = inventory.activeInHierarchy;

    	inventory.SetActive(!b);
    }

	public void LoadScene()
	{
		SceneManager.LoadScene("SampleLevel", 0);
	}
}
