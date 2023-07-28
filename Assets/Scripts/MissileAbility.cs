using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAbility : Ability
{

	GameObject target;
	public GameObject missile;

	//int usesLeft;
	//int maxUses;
    // Start is called before the first frame update
    void Start()
    {
        //maxUses = 10;
    	//usesLeft = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateAbility()
    {
    	Player player = FindObjectOfType<Player>();
    	if (player != null && usesLeft > 0)
    	{
    		GameObject ms = Instantiate(missile, player.transform.position, player.transform.rotation);
    		ms.GetComponent<PlayerMissile>().velocity = 15;
    		ms.GetComponent<PlayerMissile>().angularVelocity = 400;
    		usesLeft--;
    	}
    }

    public override void SetUses(int n)
    {
    	usesLeft = n;
    }

    public override string GetName()
    {
    	return ("Missile");
    }

    /*public override int GetUses()
    {
    	return (usesLeft);
    }*/

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
