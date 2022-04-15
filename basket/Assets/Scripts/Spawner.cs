using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private ObjectPool objectPool = null;
    [SerializeField] private int ballCounter;
    private int ballType;

    public static event Action<int> BallCounter; //Subject -> UIManagerOP.cs

    private bool spawnBallValue;

    private void Start()
    {
        ballType = ObjectPool.ballType;
        StartCoroutine(nameof(SpawnRoutine));
        BallMovement.SpawnBall += SetSpawnValue;
    }

    public void SetSpawnValue(bool spawnBall) => spawnBallValue = spawnBall; //ball movement control

    private IEnumerator SpawnRoutine()
    {
        int counter = 0;
        while (true)
        {
            if(counter!=0)
                ballCounter--;
            BallCounter?.Invoke(ballCounter);

            yield return new WaitForSeconds(spawnInterval);
            GameObject obj =  objectPool.GetPoolObject(counter++ % ballType);
            obj.transform.position = Vector3.zero;

            if (ballCounter == 0)//next level controller
            {
                PopUpOP.isFinished = true;
                Debug.Log("Top Bitti");
                break;
            }

            yield return new WaitUntil(() => spawnBallValue == true);
            spawnBallValue = false;

        }
    }
}
