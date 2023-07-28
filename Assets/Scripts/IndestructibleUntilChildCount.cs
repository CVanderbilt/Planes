using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndestructibleUntilChildCount : DestructibleObject
{
	public int minCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<DestructibleObject>().indestructible = true;
        indestructible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= minCount)
        {
        	indestructible = false;
        	gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }
}
