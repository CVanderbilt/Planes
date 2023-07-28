using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInventory : MonoBehaviour
{

	List<Ability> abs;
	Ability ab;
	int index;
	int size;
	public GameObject fields;
	Text txt;

	public Ability ability1;
	public Ability ability2;
    // Start is called before the first frame update
    void Start()
    {
        abs = new List<Ability>();

        //populate list should be made from menu before scene
        abs.Add(null);

        //Uses of each ability must be defined when added to the list
        ability1.SetUses(10);
        ability2.SetUses(15);
        abs.Add(ability1);
        abs.Add(ability2);

        size = abs.Count;
        index = 0;

        ab = abs[index];
        txt = fields.transform.Find("CurrentAbility").GetComponent<Text>();
        if (txt != null)
	        txt.text = ab != null ? ab.GetName() + ab.GetUses() : "None";

    }

    // Update is called once per frame
    void Update()
    {
    	bool changed = false;

        if (Input.GetKeyDown(KeyCode.H) && ab != null)
        {
        	changed = true;
        	ab.ActivateAbility();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
        	changed = true;
        	//index = (index + 1) % size;
        	Next();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
        	changed = true;
        	//index = (index - 1) > 0 ? index - 1 : size - 1;
        	Prev();
        }
        if (changed)
        {
        	ab = abs[index];
        	if (txt != null)
	        	txt.text = ab != null ? ab.GetName() + ab.GetUses() : "None";
        }
    }

    int Next()
    {
    	index = (index + 1) % size;
    	while (abs[index] != null && abs[index].GetUses() <= 0)
    	{
    		index += 1;
    		index %= size;
    	}
    	return (index);
    }

    int Prev()
    {
    	index = index - 1 >= 0 ? index - 1 : size - 1;
    	while (abs[index] != null && abs[index].GetUses() <= 0)
    	{
    		index -= 1;
    		index = index < 0 ? size - 1 : index; 
    	}
    	return (index);
    }
}
