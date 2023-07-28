using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{

	public int hitPoints;
	public GameObject explosion;

	public Color hurtColor;
	public float hurtDuration;

	protected Rigidbody2D body;

	public bool indestructible = false;

	bool coroutineStarted;

    // Start is called before the first frame update
    void Start()
    {
		coroutineStarted = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
    	print(col.tag);
    	if (col.transform.tag == "Player")
    		takeDamage(10);
    	if (col.transform.tag == "Bullet")
    		takeDamage(col.gameObject.GetComponent<PlayerShoot>().dmg);
    }

    public void takeDamage(int dmg)
    {
    	if (indestructible)
    		return ;
    	hitPoints -= dmg;
    	if (hitPoints <= 0)
    	{
    		if (explosion != null)
    			Instantiate(explosion, transform.position, transform.rotation);
    		Destroy(gameObject);
    	}

    	if (coroutineStarted == false)
    	{
    		coroutineStarted = true;
    		StartCoroutine(hurtFX());
    	}
    }

    //FBB871

    public IEnumerator hurtFX()
	{
		SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
		Color[] colorArray = new Color[sprites.Length];
 
 		for(int i = 0; i < sprites.Length; i++)
 		{
 			colorArray[i] = sprites[i].color;
 			sprites[i].color = hurtColor;
 		}
		 
		yield return new WaitForSeconds(hurtDuration);
		 
		for(int i = 0; i < sprites.Length; i++)
 		{
 			sprites[i].color = colorArray[i];
 		}
 		coroutineStarted = false;
	}
}
