using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstracleManager : MonoBehaviour
{

    public GameObject playerObj;
    public GameObject[] ObstraclesArr;

    int obstraclecount;
    int playerDistacneIndex = -1;
    int obstracleIndex = 0;
    int distanceToNext = 50;

    private void Start()
    {
        obstraclecount = ObstraclesArr.Length;
        InstantiateObstracle();
    }//start

    private void Update()
    {

        int playerDistance = (int)(playerObj.transform.position.y / (distanceToNext));
        if (playerDistacneIndex != playerDistance)
        {
            InstantiateObstracle();
            playerDistacneIndex = playerDistance;
        }
        print($"playerDistacneIndex - {playerDistacneIndex} , playerDistance - {playerDistance}");

    }//update

    private void InstantiateObstracle()
    {
        int randomInt = Random.Range(0,obstraclecount);
        GameObject newObstracle = Instantiate(ObstraclesArr[randomInt],new Vector3(0,obstracleIndex*distanceToNext),Quaternion.identity);
        newObstracle.transform.SetParent(transform);
        obstracleIndex++;
    }
}
