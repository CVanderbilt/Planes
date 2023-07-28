using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frag : MonoBehaviour
{
    // Start is called before the first frame update
    public float end;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > end)
        	Destroy(gameObject);
    }
}
