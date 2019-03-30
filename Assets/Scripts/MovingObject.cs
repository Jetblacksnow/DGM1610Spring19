using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    //These are for the A to B movement. 
    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;
    private Vector3 currentTarget; 
    //these are so the platform will hold the player
    public GameObject Player;



    void Start()

    {
        currentTarget= endPoint.position;


    }


    void Update()
    {
 
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position,currentTarget,moveSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent=transform;
        } 
    }
   
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject==Player)
        {
            Player.transform.parent=null;
        }
    }



}
