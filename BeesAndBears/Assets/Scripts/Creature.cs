using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Creature : MonoBehaviour
{
    float speed;
    int maxHitPoints;
    int currentHitPoints;
    int maxPointsOfCapacity;
    int currentPointsOfCapacity;
    int takePerTime;
    bool isMoving;
    Vector3 startPosition;
    Vector3 currentPosition;
    Vector2 moveDirection = new Vector2(1, 0);
    Collider2D circleColider;
    [SerializeField] GameObject StartPointPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Set characteristic of creature
        currentHitPoints = maxHitPoints;
        startPosition = gameObject.transform.position;
        currentPosition = startPosition;
        string tag = gameObject.tag;
        if (tag == "Bee")
        {
            speed = 2;
            maxHitPoints = 100;
            maxPointsOfCapacity = 100;
            currentPointsOfCapacity = 0;
            takePerTime = 50;            
        }
        if (tag == "Flover")
        {
            speed = 0;
            maxHitPoints = 100;
            maxPointsOfCapacity = 100;
            currentPointsOfCapacity = maxPointsOfCapacity;
            takePerTime = 0;
        }
        circleColider = gameObject.GetComponent<CircleCollider2D>();

                      
        if (currentPosition.x <= 0)
        {
            moveDirection.x = 1;
        }
        else 
        {
            moveDirection.x = -1;
            transform.Rotate(Vector3.up, 180f);
        } 
    }

    // Update is called once per frame
    void Update()
    {        
        if (isMoving) 
        {
            Move();
        }        
       // Debug.Log(isMoving);
       
    }
    
    void OnMouseOver()
    {
        // Activate creature's move
       if (Input.GetMouseButtonDown(0))
        {
           isMoving = true;            
        }      
    }
    void Move()
    {
        currentPosition.x += speed * moveDirection.x * Time.deltaTime;
        gameObject.transform.position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        // Get honey and go to back
        if (collision.gameObject.tag == TagsHolder.FloverTag) 
        {
            transform.Rotate(Vector3.up, 180f);
            moveDirection.x *= -1;
            currentPointsOfCapacity = takePerTime;            
        }
        //stop moving if back to the start
        if (collision.gameObject.tag == TagsHolder.StartPointTag)
        {
            transform.Rotate(Vector3.up, 180f);
            moveDirection.x *= -1;
            isMoving = false;                       
        }
        // Get honey if you a flover
        if (collision.gameObject.tag == TagsHolder.BeeTag) 
        {
            if (currentPointsOfCapacity > 0) 
            {
                int amountOfHoney = collision.gameObject.GetComponent<Creature>().takePerTime;
                GetHoney(amountOfHoney);
                print($"{gameObject.name} Amount of honey = {currentPointsOfCapacity}");
            }
            if (currentPointsOfCapacity <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GetHoney(int amountOfHoney) 
    {
        currentPointsOfCapacity -= amountOfHoney;
    }
}
