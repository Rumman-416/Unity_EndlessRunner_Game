using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffSet;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f;
    private Vector3 animationoffset = new Vector3(0, 5, 5);
    void Start()
    {
        lookAt= GameObject.FindGameObjectWithTag("Player").transform;
        startOffSet = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffSet;
        //X
        //moveVector.x = 0;
        //Y
        moveVector.y = Mathf.Clamp(moveVector.y,3,5);
        
        if(transition> 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            //Animation at start
            transform.position = Vector3.Lerp(moveVector + animationoffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
        }
        
    }
}
