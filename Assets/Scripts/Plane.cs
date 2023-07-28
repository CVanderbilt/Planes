using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Enemy
{

	//public int hitPoints = 1;
	//public GameObject explosion;

	//public float speed  = 8;
	public float angularSpeed = 50;
	public float turningDuration = 0.5f;
	float angularSpeedMod;

	public bool willTurn;
	public float timeToTurn;
	public float turnWhenReached;
	public bool aproachFromRight;
	bool startedRotating;

	Rigidbody2D body;
	public float angle;
	public float targetAngle;

	//public float frequency;
	//public GameObject bullet;
	//public float bulletSpeed;
	//float nextShoot;

	public float willDie = 5;

	Vector2 direction;
	Animator anim;

	float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
    	nextShoot = Time.time + Random.Range(0.0f, frequency);

    	willDie += Time.time;
    	startedRotating = false;
    	if (transform.position.x >= turnWhenReached)
    		aproachFromRight = false;
    	else
    		aproachFromRight = true;
        body = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();

        angularSpeedMod = angularSpeed;
        currentSpeed = speed;

        
    }

    // Update is called once per frame
    void Update()
    {
    	//float new_angle;
        
        //SetAnimation();
        //transform.eulerAngles = Vector3.forward * angle;

    	if (Time.time >= willDie)
    		Destroy(gameObject);

        transform.eulerAngles = Vector3.forward * angle;
        if (willTurn && (startedRotating || CheckPos(aproachFromRight, turnWhenReached)))
        {
        	startedRotating = true;
        	/*angle += angularSpeed * Time.deltaTime;
        	if (angle >= 365)
        		angle = 0;*/
        	angle = Mathf.SmoothDamp(angle, targetAngle, ref angularSpeedMod, turningDuration);

        	if (Mathf.Abs(angle - targetAngle) <= 0.1f)
        		willTurn = false;
        }

        direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        direction.Normalize();

        SetAnimation();
        Shoot();
    }

    void FixedUpdate()
    {
    	body.position += direction * speed * Time.fixedDeltaTime;
    }

    void SetAnimation()
    {
    	anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);
    }

    bool CheckPos(bool rightFromTarget, float target)
    {
    	if (rightFromTarget)
    	{
    		if (transform.position.x > target)
    			return true;
    	}
    	else
    		if (transform.position.x < target)
    			return true;
    	return false;
    }
}
