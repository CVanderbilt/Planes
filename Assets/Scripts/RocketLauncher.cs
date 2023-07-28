using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

	//public GameObject missile;
	Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        //nextShoot = Time.time + Random.Range(0.0f, frequency);

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
		}

		//Shoot();
    }

    void FixedUpdate()
    {

    }
}
