using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject playerObj;
    float smootTime = 0.15f;
    Vector3 velocity = Vector3.zero;
    public int yOffSet = 5;

    private void Update()
    {
        FollowPlayerObj();
    }

    private void FollowPlayerObj()
    {
        Vector3 targetPosition = playerObj.transform.TransformPoint(new Vector3(0, yOffSet, -10));
        targetPosition = new Vector3(0,targetPosition.y,targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smootTime);
    }

}
