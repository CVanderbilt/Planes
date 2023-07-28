using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragAbility : Ability
{
    // Start is called before the first frame update
    public GameObject frag;
    //int maxUses;
    //int usesLeft;

    void Start()
    {
    	//maxUses = 15;
    	//usesLeft = 15;
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
    		GameObject ms = Instantiate(frag, player.transform.position, player.transform.rotation);
    		ms.GetComponent<Frag>().end = Time.time + 0.2f;
    		usesLeft--;
    	}
    }

    public override void SetUses(int n)
    {
    	usesLeft = n;
    }

    public override string GetName()
    {
    	return ("Frag");
    }

    /*public override int GetUses()
    {
    	return (usesLeft);
    }*/
}
