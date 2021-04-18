using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstracle : MonoBehaviour
{

    public int rotationSpeed;

    private void Update()
    {
        if (rotationSpeed != 0)
        {
            Rotation();
        }
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
