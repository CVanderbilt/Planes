using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCannon : MonoBehaviour
{
    // Start is called before the first frame update

    //Player player;
    
    public GameObject bullet;
    public float bulletSpeed;
    public float frequency = 2;

	public bool randomOffset = true;

    float nextShoot;
    float leftLimit;
    float rightLimit;

    Player player;


    void Start()
    {
    	//player = FindObjectOfType<Player>();
    	player = FindObjectOfType<Player>();
    	nextShoot = Time.time + frequency + Random.Range(0.0f, frequency);
    }

    // Update is called once per frame
    void Update()
    {
    	
    	if (player != null)
    	{
			Vector3 vectorToTarget = player.transform.position - transform.position;
			float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5);

			if (Time.time >= nextShoot)
			{
				nextShoot = Time.time + frequency;

				GameObject clone;
		        clone = Instantiate(bullet, transform.position, transform.rotation);
		        //clone.GetComponent<Rigidbody2D>().velocity = bulletSpeed * -1 * transform.TransformDirection(transform.rotation.eulerAngles);
		        clone.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
		        Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
			}
		}
    }
}
