using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
	public bool godMode  = false;

    public float vSpeed = 8;
    public float hSpeed = 15;

    public float bulletSpeed;

    public float vulnerableTime = 1.5f;
    public float invulnerableTime = 0.5f;
    public int lifes = 5;
    public bool isVulnerable;
    float endVulnerability;
    float endInvulnerability;

    public Vector2 movVector;
    public GameObject bullet;
    public GameObject explosion;

    public float frequency;
    float coolDown;

    bool shooting;

    HealthBar healthBar;
    Rigidbody2D body;
    Animator animator;
    //float speedOffset;

    public Ability ab;

    public void setUp(ItemPlane plane)
    {

    }

    void Start()
    {
    	isVulnerable = false;
    	isVulnerable = false;
    	shooting = false;

     	body = GetComponent<Rigidbody2D>();  
     	animator = GetComponent<Animator>();
     	healthBar = FindObjectOfType<HealthBar>();
     	healthBar.SetMaxHealth(lifes);
     	healthBar.SetHealth(lifes);
     	//speedOffset = Camera.main.GetComponent<CameraScript>().speed;
    }

    // Update is called once per frame
    void Update()
    {
    	animator.SetInteger("Direction", ManageInputs());

    	if (isVulnerable && lifes > 0)
    	{
    		if (Time.time >= endVulnerability)
    		{
    			isVulnerable = false;
    			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    		}
    	}

    	if (Time.time > endInvulnerability)
    		gameObject.layer = LayerMask.NameToLayer("Default");

    	if (shooting && Time.time >= coolDown)
    	{
    		GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(); 
			if (bullet != null)
			{
				bullet.transform.position = transform.position;
				bullet.transform.rotation = transform.rotation;

				bullet.SetActive(true);
				bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed + hSpeed, 0);
				bullet.layer = LayerMask.NameToLayer("Projectile");

				coolDown = Time.time + frequency;
			}
    	}


    }

    void FixedUpdate()
    {
    	body.MovePosition(transform.localPosition + new Vector3(movVector.x * hSpeed /*+ speedOffset*/, movVector.y * vSpeed, 0) * Time.deltaTime);
    	//rigidbody.MovePosition(rigidbody.position + hMove + vMove);
    }

    private int ManageInputs()
    {
    	float y = Input.GetAxis("Vertical");
    	float x = Input.GetAxis("Horizontal");

    	movVector = new Vector2(x, y);

    	if (Input.GetKeyDown(KeyCode.Space))
    		shooting = true;
    	if (Input.GetKeyUp(KeyCode.Space))
    		shooting = false;

    	if (y > 0)
    		return (1);
    	if (y < 0)
    		return (-1);
    	return (0);
    }

    public void Hitted()
    {
    	if (godMode)
    		return ; 
    	if (isVulnerable)
    	{
    		lifes = 0;
    		//healthBar.SetHealth(0);
    		if (explosion != null)
    			Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}
    	lifes -= 1;
    	healthBar.SetHealth(lifes);
    	isVulnerable = true;
    	gameObject.layer = LayerMask.NameToLayer("Ignore");
    	endInvulnerability = Time.time + invulnerableTime;
    	GetComponent<SpriteRenderer>().color = Color.red;
    	endVulnerability = Time.time + vulnerableTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.transform.tag == "Enemy")
    	{
    		Hitted();
	    	//Destroy(gameObject);
    	}
    }
}
