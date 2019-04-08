using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject followTarget;
    public float followAhead;
    private Vector3 targetPosition;
    public float smooth;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //follow the "target", in this case the player.
        targetPosition = new Vector3(followTarget.transform.position.x,transform.position.y,transform.position.z);
        // the player animation are tied to it's scale, I need the camera to follow in both directions. 
        if(followTarget.transform.localScale.x>0f)
        {
            targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y,targetPosition.z);

        } else{
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y,targetPosition.z);
              }
    
       // transform.position =targetPosition;
        transform.position = Vector3.Lerp(transform.position,targetPosition,smooth*Time.deltaTime);            
            
        
    }
}
