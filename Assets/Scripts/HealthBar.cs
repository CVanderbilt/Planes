using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider s;

    void Awake()
    {
        s = GetComponent<Slider>();
    }

    void Start()
    {
    	//s = GetComponent<Slider>();
    }

    public void SetMaxHealth(int max)
    {
    	s.maxValue = max;
    }

    public void SetHealth(int health)
    {
    	s.value = health;
    }
}
