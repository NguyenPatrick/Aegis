using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    // enemy types
    public GameObject Reaper;
    public GameObject Pyromancer;

    // spawn points
    private Transform firstSpawnPoint;
    private Transform secondSpawnPoint;
    private Transform thirdSpawnPoint;
    private Transform fourthSpawnPoint;
    private Transform fifthSpawnPoint;
    private Transform spawnPoint;


    void Start()
    {
        firstSpawnPoint = GameObject.Find("FirstSpawn").transform;
        secondSpawnPoint = GameObject.Find("SecondSpawn").transform;
        thirdSpawnPoint = GameObject.Find("ThirdSpawn").transform;
        fourthSpawnPoint = GameObject.Find("FourthSpawn").transform;
        fifthSpawnPoint = GameObject.Find("FifthSpawn").transform;
    }

    void Update()
    {
        int randomSpawnPointNumber;
        randomSpawnPointNumber = Random.Range(1, 6);

        if (randomSpawnPointNumber == 1)
        {
            spawnPoint = firstSpawnPoint;
        }
        else if (randomSpawnPointNumber == 2)
        {
            spawnPoint = secondSpawnPoint;
        }
        else if (randomSpawnPointNumber == 3)
        {
            spawnPoint = thirdSpawnPoint;
        }
        else if (randomSpawnPointNumber == 4)
        {
            spawnPoint = fourthSpawnPoint;
        }
        else if (randomSpawnPointNumber == 5)
        {
            spawnPoint = fifthSpawnPoint;
        }

        //Instantiate(Reaper, firstSpawnPoint.position, firstSpawnPoint.rotation);
    }
}