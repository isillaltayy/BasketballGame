using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class BallMovement : MonoBehaviour
{
    private Rigidbody ballRigidBody;
    public bool isMoved = false;
    public bool newSpawn = false;

    [SerializeField]
    private float forceMultiplierX = 1300;
    [SerializeField]
    private float forceMultiplierYZ = 500;
    [SerializeField]
    private float BallPingPongMovementVelocity;

    public static event Action<bool> SpawnBall; //Subject

    public ItemType item;

    private Vector3 mousePressDownPosition;
    private Vector3 mouseReleasePosition;
    private Vector3 currentSwipeForce;
    private bool isShoot;

    private void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        StartCoroutine(nameof(EndBallRoutine));
        transform.localScale = item.scale;
        ballRigidBody.mass = item.mass;
        BallPingPongMovementVelocity = item.PingPongVelocity;
    }

    void Update()
    { 
        if (!isMoved && !newSpawn)
        {
            transform.position = new Vector3(0, -.5f, Mathf.PingPong(Time.time * BallPingPongMovementVelocity, 10)-5);
        }     
    }
    public void OnMouseDown()
    {
       mousePressDownPosition = Input.mousePosition;
       Debug.Log(mousePressDownPosition);
    }
    public void OnMouseUp()
    {
        mouseReleasePosition = Input.mousePosition;
        touchSwipe(mousePressDownPosition - mouseReleasePosition);
        Debug.Log(mouseReleasePosition);
    }
   
    private void touchSwipe(Vector3 Force)
    {
        if (isShoot)
            return;
        currentSwipeForce = Force.normalized;
        Debug.Log(currentSwipeForce);


        if (currentSwipeForce.y < 0 && currentSwipeForce.x > -1f && currentSwipeForce.x < 1f )
        {
            ballRigidBody.AddForce(-Mathf.Abs(Force.x * forceMultiplierX), Force.y * forceMultiplierYZ, Force.z * forceMultiplierYZ);
            isShoot = true;
            isMoved = true;
            StartCoroutine(nameof(EndBallRoutine));
            SpawnBall?.Invoke(isMoved);
        }
    }

    private IEnumerator EndBallRoutine()
    {
        if (isMoved == true)
        {
            yield return new WaitForSecondsRealtime(5f);
            this.gameObject.SetActive(false);
            newSpawn = true;
            ballRigidBody.velocity = Vector3.zero;
            ballRigidBody.angularVelocity = Vector3.zero;
        }
        isMoved = false;
    }
}
