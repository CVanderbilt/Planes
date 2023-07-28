using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start, update and the rest of functions to override are handled by childs.

	//public int hitPoints = 1;
	//public GameObject explosion;
	public float speed  = 8;

	public float frequency;
	public GameObject bullet;
	public float bulletSpeed;
	protected float nextShoot;

	void Start()
	{
		nextShoot = Time.time + Random.Range(0.0f, frequency);
	}

	void Update()
	{
		Shoot();
	}

	//protected Rigidbody2D body;

	/*protected void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag == "Player")
    		takeDamage(10);
    	if (col.transform.tag == "Bullet")
    		takeDamage(col.gameObject.GetComponent<PlayerShoot>().dmg);
    }*/

    /*public void takeDamage(int dmg)
    {
    	hitPoints -= dmg;
    	if (hitPoints <= 0)
    	{
    		if (explosion != null)
    			Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    }*/

    public void Shoot()
    {
    	Player player = FindObjectOfType<Player>();
    	if (player != null)
    	{
			Vector3 vectorToTarget = (player.transform.position - transform.position);
			vectorToTarget.z = 0;
			vectorToTarget.Normalize();

			if (Time.time >= nextShoot)
			{
				nextShoot = Time.time + frequency;

				GameObject clone;
		        clone = Instantiate(bullet, transform.position, transform.rotation);
		        clone.GetComponent<Rigidbody2D>().velocity = vectorToTarget * bulletSpeed;
		        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
		}
    }
}
