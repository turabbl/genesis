using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float angle = 0;
    int xSpeed = 3;
    int YSpeed = 10;

    GameManager gameManagerObj;

    public GameObject deadEffect;
    public GameObject itemEffect;

    bool isDead = false;
    float hueValue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManagerObj = GameObject.Find("GameManager").GetComponent<GameManager>();
    }           

    private void Start()
    {
        itemEffect.SetActive(false);
        hueValue = Random.Range(0, 10) / 10.0f;
        SetBackgroundColor();
    }

    private void Update()
    {
        if (isDead == true) return;

        MovePlayer();
        GetInput();
    }
    float time;
    void GetInput()
    {
        print(time);
        if (Input.GetMouseButton(0) && time < 4)
        {
            time += Time.deltaTime;
            rb.AddForce(new Vector2(0, YSpeed));
            if (time == 3)
            {
                time = 0;
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2(0, -YSpeed/2f));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x,0);
                time = 0.0f;
            }
        }
    }

    void MovePlayer()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 3;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstracle")
        {
            Dead();
        }
        else if (other.gameObject.tag == "Item")
        {
            GetItem(other);      
        }
 

    }

    private void GetItem(Collider2D other)
    {
        SetBackgroundColor();
        itemEffect.SetActive(true);
        Destroy(Instantiate(itemEffect,other.gameObject.transform.position,Quaternion.identity),0.5f);
        Destroy(other.gameObject.transform.parent.gameObject);

        gameManagerObj.AddScore();
    }

    void StopPlayer()
    {
        rb.velocity = new Vector2(0,0);
        rb.isKinematic = true;
    }

    void Dead()
    {
        isDead = true;

        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());

        Destroy(Instantiate(deadEffect,transform.position,Quaternion.identity),0.7f);
        StopPlayer();
        gameManagerObj.CallGameOver();
    }


    void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);

        hueValue += 0.1f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }
}
