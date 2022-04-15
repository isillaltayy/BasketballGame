using UnityEngine;
using System;

public class ScoreArea : MonoBehaviour
{
    private int score;
    public static event Action<int> OnBasketCollected; //Subject
    public static event Action<int> EndBasketCollected;

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallMovement>() != null)
        {
            score++;
            OnBasketCollected?.Invoke(score);
            EndBasketCollected?.Invoke(score);
        }
    }
}
