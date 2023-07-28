using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBoss : MonoBehaviour
{
    // Start is called before the first frame update

	//public event Action OnBossDeath;
	public GameObject dest;
	public float speed;

	Vector2 targetPos;
	Rotation rot;
	int initialChilds;

    void Start()
    {
    	targetPos = (Vector2)transform.position;
    	if (dest != null)
    		targetPos = dest.transform.position;
    	rot = GetComponent<Rotation>();

    	initialChilds = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
        	GetComponent<BossEvents>().Die();
        	Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        rot.angularSpeed = 5 + (initialChilds - transform.childCount) * 10;
    }
}
