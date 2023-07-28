using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag != "Bullet" && col.transform.tag != "Enemy")
    	{
    		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    		if (col.transform.tag == "Player")
    		{
    			col.transform.GetComponent<Player>().Hitted();
    		}
    		Destroy(gameObject);
    	}
    }
}
