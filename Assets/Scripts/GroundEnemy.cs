using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{

	//public int hitPoints = 5;
	
	Rigidbody2D body;
	Player player;
	//public GameObject explosion;
	float speedOffset;

	float leftLimit;
	float rightLimit;

    // Start is called before the first frame update
    void Start()
    {
    	//hitPoints = 5;
        body = GetComponent<Rigidbody2D>();
        speedOffset = SharedScript.horizontalConstantSpeed;
        //turret = transform.Find("TurretCannon").gameObject;
        
        DeathLimits obj = FindObjectOfType<DeathLimits>();
        leftLimit = obj.leftLimit;
        rightLimit = obj.rightLimit;
    }

    // Update is called once per frame
    void Update()
    {
    	if (transform.position.x <= leftLimit || transform.position.x >= rightLimit)
    		Destroy(gameObject);
    	//Shoot();
    }

    void FixedUpdate()
    {
    	body.MovePosition(transform.localPosition + new Vector3(speedOffset, 0, 0) * Time.fixedDeltaTime);
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag == "Player")
    		takeDamage(10);
    	if (col.transform.tag == "Bullet")
    		takeDamage(col.gameObject.GetComponent<PlayerShoot>().dmg);
    }

    void takeDamage(int dmg)
    {
    	hitPoints -= dmg;
    	if (hitPoints <= 0)
    	{
    		if (explosion != null)
    			Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    }*/
}
