using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
   
    public Sprite flagClosed;
    public Sprite flagOpen;

    private SpriteRenderer theSpriteRenderer;


    void Start()
    {
        
        theSpriteRenderer = GetComponent<SpriteRenderer>();


    }

    
    void Update()
    {
        
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            theSpriteRenderer.sprite = flagOpen;
        }
    }


}
