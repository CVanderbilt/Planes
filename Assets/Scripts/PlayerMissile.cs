using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{

	public GameObject explosion;
	GameObject target;
	Rigidbody2D body;

	public float velocity = 5;
	public float angularVelocity = 200;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        	target = FindClosestEnemy();
    }

    void FixedUpdate()
    {
    	float crossValue = 0;
    	if (target != null)
    	{
    		Vector2 ptrToTarget = (Vector2)transform.position - (Vector2)target.transform.position;
    		ptrToTarget.Normalize();

    		crossValue = Vector3.Cross(ptrToTarget, transform.right).z;
    	}

    	if (crossValue > 0)
    		body.angularVelocity = angularVelocity;
    	else if (crossValue < 0)
    		body.angularVelocity = -angularVelocity;
    	else
    		body.angularVelocity = 0;

    	body.velocity = transform.right * velocity;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector2 position = (Vector2)transform.position;
        foreach (GameObject go in gos)
        {
        	Vector2 posInCamera = (Vector2)Camera.main.WorldToViewportPoint(go.transform.position);
        	if (posInCamera.x < 1 && posInCamera.x > 0 && posInCamera.y < 1 && posInCamera.y > 0)
        	{
	            Vector2 diff = (Vector2)go.transform.position - position;
	            float curDistance = diff.sqrMagnitude;
	            if (curDistance < distance)
	            {
	                closest = go;
	                distance = curDistance;
	            }
        	}
        }
        return closest;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag == "Enemy")
    	{
    		Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    }
}
