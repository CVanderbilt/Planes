using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

	public static ObjectPooler SharedInstance;

	public List<GameObject> pooledObjects;
	public GameObject objectToPool;
	public int amountToPool;

	void Awake() {
		SharedInstance = this;
	}
    // Start is called before the first frame update
    void Start()
    {
    	pooledObjects = new List<GameObject>();
		for (int i = 0; i < amountToPool; i++)
		{
			GameObject obj = (GameObject)Instantiate(objectToPool);
			obj.SetActive(false); 
			pooledObjects.Add(obj);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
				return pooledObjects[i];
		}
		return null;
	}
}
