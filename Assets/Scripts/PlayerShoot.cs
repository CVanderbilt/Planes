using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	//public float speed;
    //public GameObject explosion;
	public int dmg = 1;
    public bool pooling  = false;
    public bool destroyable = true;

	Rigidbody2D body;
    void Start()
    {
    	//GetComponent<Animator>().SetBool("Hit", false);
        body = GetComponent<Rigidbody2D> ();
        //body.velocity += new Vector2 (speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //body.velocity += new Vector2 (speed, 0);
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
    	//transform.Translate(Vector2.right * speed * Time.deltaTime);
    	
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag != "Player" && col.transform.tag != "Bullet")
    	{
            if (body != null)
    		  body.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer("Ignore");
            if (!destroyable)
                return ;
            if (pooling)
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
            //speed = 0;
    		//GetComponent<Animator>().SetBool("Hit", true);
	    	//Destroy(gameObject);
    	}
    }

    private void OnEnable(){
        //GetComponent<Rigidbody2D>().velocity = 10 * transform.forward;
    }
}

