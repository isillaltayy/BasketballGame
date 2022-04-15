using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator animator;
    bool isMainCamera=true;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraChange();
        }
        
    }
    public void cameraChange()
    {
        if (isMainCamera)
        {
            animator.Play("MainCamera");
        }
        else
        {
            animator.Play("BallCamera");
        }
        isMainCamera = !isMainCamera;
    }
}
