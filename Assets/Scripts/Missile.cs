using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
	Rigidbody2D body;
	Player player;

	public float lifeTime  = 3;
	public GameObject explosion;

    void Start()
    {
        player = FindObjectOfType<Player>();
        body = GetComponent<Rigidbody2D>();

        lifeTime += Time.time;
    }

    float angle;
    Vector3 dir;
    // Update is called once per frame
    void Update()
    {
    	if (Time.time >= lifeTime)
    	{
    		Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    }

    void FixedUpdate()
    {
    	float crossValue = 0;
    	if (player != null)
    	{
    		Vector2 ptrToTarget = (Vector2)transform.position - (Vector2)player.transform.position;
    		ptrToTarget.Normalize();

    		crossValue = Vector3.Cross(ptrToTarget, transform.right).z;
    	}

    	if (crossValue > 0)
    		body.angularVelocity = 200;
    	else if (crossValue < 0)
    		body.angularVelocity = -200;
    	else
    		body.angularVelocity = 0;

    	body.velocity = transform.right * 5;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag == "SceneLimits")
    		return ;
    	//if (col.transform.tag != "Bullet" && col.transform.tag != "Enemy")
    	{
    		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    		if (col.transform.tag == "Player")
    		{
    			col.transform.GetComponent<Player>().Hitted();
    		}
    		Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    }
}
