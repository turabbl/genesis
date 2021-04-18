﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleParent : MonoBehaviour
{

    GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.Find("Player");
        StartCoroutine(CalculateDistanceToPlayer());
    }

    IEnumerator CalculateDistanceToPlayer()
    {
        while (true)
        {
            if (playerObj.transform.position.y - transform.position.y > 50)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }


}
