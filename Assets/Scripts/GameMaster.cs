using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

	public GameObject turret;

    public GameObject winScreenObject;

	public GameObject turretWave0;
	public GameObject chopper2TopWave0;
	public GameObject multipleWave0;
	public GameObject planeWave0;
	public GameObject crazyWave;

    public GameObject boss;
    public float bossOffset = 5;

	public float timeBetweenWaves;

	public int index;
	int maxIndex;

	GameObject[] waveArray;
	Vector2[] offsetArray;

	float nextWave;

    //GameObject enemyArray;
	//Distintos eventos que invocan enemigos con sus elementos, directamente activados
	//Eventos activados por tiempo, puedo diseñar cada función para ser acrivada desde el Update, las metemos un array
	//Alternativa: prefabs para cada oleada, se irán llamando desde aquí, los diseño en editor pero se intsancian desde aqui, se soluciona tema posiciones y demás

    // Start is called before the first frame update
    bool bossSpawned;

    void Start()
    {

        winScreenObject.SetActive(false);
    	print("solo deberia estar entrando una vez");
    	nextWave = Time.time;
    	/*GameObject clone = Instantiate(turretWave0, transform.position, transform.rotation);
    	clone.transform.DetachChildren();
    	Destroy(clone);*/

    	waveArray = new GameObject[7];
    	offsetArray = new Vector2[7];

    	waveArray[0] = turretWave0;
    	waveArray[1] = chopper2TopWave0;
    	waveArray[2] = multipleWave0;
    	waveArray[3] = turretWave0;
    	waveArray[4] = planeWave0;
    	offsetArray[4].y = 2;
    	waveArray[5] = crazyWave;
    	waveArray[6] = planeWave0;



    	index  = 0;
    	maxIndex = waveArray.Length;

        bossSpawned = false;

        //Vector3 position = transform.position;
        //GameObject clone = Instantiate(boss, position, transform.rotation);
        //SharedScript.MoveTo2D(ref clone, transform.position - new Vector3(2, -2));

    }

    // Update is called once per frame
    void Update()
    {
        //MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
        //Vector3 position = transform.position + new Vector3(offsetArray[index].x, offsetArray[index].y, 0);
        //return ;

        //GameObject clone = Instantiate(boss, transform.position, transform.rotation);
        if (Time.time >= nextWave && index < maxIndex)
        {
        	Vector3 position = transform.position + new Vector3(offsetArray[index].x, offsetArray[index].y, 0);
        	GameObject clone = Instantiate(waveArray[index], position, transform.rotation);
        	clone.transform.DetachChildren();
        	Destroy(clone);

        	nextWave = Time.time + timeBetweenWaves;
        	index++;
            if (index >= maxIndex)
                bossOffset += Time.time;
        }
        else if (!bossSpawned && index >= maxIndex && Time.time >= bossOffset)
        {
            GameObject bossClone = Instantiate(boss, transform.position, transform.rotation);
            BossEvents bs = bossClone.GetComponentInChildren<BossEvents>();
            if (bs != null)
                bs.OnBossDeath += WinScreen;
            bossClone.transform.DetachChildren();
            Destroy(bossClone);
            bossSpawned = true;
        }


        //enemyArray = gameObject.FindGameObjectsWithTag("Enemy");
    }

    void WinScreen()
    {
        //enableará el menu de victoria desde donde se puede continuar, reintentar o volver al menu
        winScreenObject.SetActive(true);
    }

    void GameOverScreen()
    {
        //enableará el menu de victoria desde donde se puede reintentar o volver al menu, continuar estará bloqueado
    }

    void EjemploCrearOleada()
    {
    	//Crea torretas, la posición del objeto es la esquina abajo-derecha
	    Instantiate(turret, transform.position, transform.rotation);
	    Instantiate(turret, transform.position + new Vector3 (5, 0, 0), transform.rotation);
	    Instantiate(turret, transform.position + new Vector3 (10, 0, 0), transform.rotation);
	    Instantiate(turret, transform.position + new Vector3 (15, 0, 0), transform.rotation);

    }

    void TurretSpawner(int numberOfEnemies, float distanceBetweenEnemies, float initialDistance, float height)
    {
    	Vector3 position = new Vector3(transform.position.x + initialDistance, transform.position.y + height, 0);
    	for (int i = 0; i < numberOfEnemies; i++)
    	{
    		Instantiate(turret, position, transform.rotation);
    		position.x += distanceBetweenEnemies;
    	}
    }
}
