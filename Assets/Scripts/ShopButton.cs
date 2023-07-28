using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButton : MonoBehaviour
{
	public ShopItem item;
	public Sprite none;
    // Start is called before the first frame update
    void Start()
    {
    	Sprite im;
    	string nm = "empty";

     	im = item != null ? item.GetImage() : null;
     	if (item != null)
     	{
     		im = item.GetImage();
     		nm = item.GetName() + " (" + item.GetPrice() + ")";
     	}
     	GetComponent<Image>().sprite = im != null ? im : none;
     	GetComponentsInChildren<TextMeshProUGUI>()[0].text = nm;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ShopItem GetItem()
    {
    	return item;
    }

}
