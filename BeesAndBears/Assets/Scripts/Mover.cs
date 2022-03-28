using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mover : MonoBehaviour
{    
    Collider2D beeCollider;
    float speedOfBee;
    float moveDirectionDegrees;
    Vector3 moveDirection;
    Vector3 positionOfBee;
    Vector3 destinationCell;
    Vector3 startBeePosition;
    bool moving;
    bool rotated;
    bool clicked;
    GameObject gameCell;

    // Start is called before the first frame update
    void Start()
    {
        beeCollider = gameObject.GetComponent<CircleCollider2D>();
        speedOfBee = 2;
        positionOfBee = gameObject.transform.position;
        startBeePosition = positionOfBee;
        moving = false;
        rotated = false;
        clicked = false;
        //gameCell = GameObject.FindGameObjectWithTag("Cell");
        //destinationCell = gameCell.transform.position;

        /* Decide which direction bee have to move
        moveDirection.x = destinationCell.x - positionOfBee.x;
        moveDirection.y = destinationCell.y - positionOfBee.y;
        moveDirection.Normalize();
        */
    }

    // Update is called once per frame
    void Update()
    {


        if (moving)
        {
            Move();
        }

        // Stop moving
        if (destinationCell.x == positionOfBee.x && destinationCell.y == positionOfBee.y)
        {
            moving = false;
        }

        // Rotate the bee        
        if (moveDirection.x < 0 && rotated == false)
        {
            transform.Rotate(Vector3.up, 180f);
            rotated = true;
        }

    }

    // Make the bee move
    void OnMouseOver()
    {
        // Activate bee's move
        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
        }

    }

    private void Move()
    {
        positionOfBee.x += Time.deltaTime * speedOfBee * moveDirection.x;
        positionOfBee.y += Time.deltaTime * speedOfBee * moveDirection.y;
        gameObject.transform.position = positionOfBee;
    }
}
