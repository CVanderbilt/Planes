using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossEvents : MonoBehaviour
{
	// de momento solo tiene el de avisar cuando muere pero si hacen falta más se irán añadiendo
	// este código se puede enganchar a cualquier boss, game master cada vez q invoque a un boss
	// buscará esto y si lo encuentra se suscribe al evento que necesite, si no lo encontrara es
	// porq no es el boss final y no tiene q provocar fin de escena al ser destruido
	public event Action OnBossDeath;

	public void Die()
	{
		OnBossDeath();
	}

}
