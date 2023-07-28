using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperScript : Enemy
{
    // Start is called before the first frame update
    //public GameObject explosion;
    public Transform pathHolder;
    public float waitTime = 0;
    //public float speed = 5;
    //public int hitPoints = 1;

    //public GameObject bullet;
    //public float bulletSpeed;
    //public float frequency = 2;
    public float offset = 0;
    public bool randomOffset = true;
    //float nextShoot;

    int index;
    int maxIndex;
    Vector3[] waypoints;
    Vector3 direction;
    Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
    	nextShoot = Time.time + frequency + Random.Range(0.0f, frequency);

    	maxIndex = pathHolder.childCount;
        waypoints = new Vector3[maxIndex];
        body = GetComponent<Rigidbody2D>();
        index = 0;
        for (int i = 0; i < pathHolder.childCount; i++)
        {
        	waypoints[i] = pathHolder.GetChild(i).position;
        	//waypoints[i].y = transform.position.y;
        	waypoints[i].z = 0;
        }
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	//print("moving to: " + waypoints[index]);
    	if(Vector2.Distance(transform.position, waypoints[index]) < 0.1f)
    	{
    		index++;
    		if (index >= maxIndex)
    			Destroy(gameObject);
    	}
    	if (index < maxIndex)
    	{
	    	direction = (transform.position - waypoints[index]);
	    	direction.z = 0;
	    	direction.Normalize();
    	}
    	Shoot();
    }

    void FixedUpdate()
    {
    	body.position = Vector2.MoveTowards(body.position, waypoints[index], speed * Time.fixedDeltaTime);
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag == "Player")
    		takeDamage(10);
    	if (col.transform.tag == "Bullet")
    		takeDamage(col.gameObject.GetComponent<PlayerShoot>().dmg);
    }*/

    /*void Shoot()
    {
    	Player player = FindObjectOfType<Player>();
    	if (player != null)
    	{
			Vector3 vectorToTarget = (player.transform.position - transform.position);
			vectorToTarget.z = 0;
			vectorToTarget.Normalize();
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
 			Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
			//float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			//transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);

			if (Time.time >= nextShoot)
			{
				nextShoot = Time.time + frequency;

				GameObject clone;
		        clone = Instantiate(bullet, transform.position, rot);
		        //clone.GetComponent<Rigidbody2D>().velocity = bulletSpeed * -1 * transform.TransformDirection(transform.rotation.eulerAngles);
		        clone.GetComponent<Rigidbody2D>().velocity = vectorToTarget * bulletSpeed;
		        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
		}
    }*/

    /*void takeDamage(int dmg)
    {
    	hitPoints -= dmg;
    	if (hitPoints <= 0)
    	{
    		if (explosion != null)
    			Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    }*/

    void OnDrawGizmos()
    {
    	Vector2 start = pathHolder.GetChild(0).position;
    	Vector2 prev = start;
    	foreach(Transform waypoint in pathHolder)
    	{
    		Gizmos.DrawSphere(waypoint.position, 0.3f);
    		Gizmos.DrawLine(prev, waypoint.position);
    		prev = waypoint.position;
    	}
    	//Gizmos.DrawLine(prev, start);
    }
}
