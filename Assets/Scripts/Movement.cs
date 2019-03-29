using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public float moveSpeed;
    public GameObject Platform;

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

    private void Start() 
    
    {
        Platform = GetComponet<GameObject>(this.GameObject);

    }
        void update( )
        {





        }



}
