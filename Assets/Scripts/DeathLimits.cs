using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLimits : MonoBehaviour
{
    // Start is called before the first frame update

	public float leftLimit;
	public float rightLimit;

    void Start()
    {
        leftLimit = transform.GetChild(0).transform.position.x;
        rightLimit = transform.GetChild(1).transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
