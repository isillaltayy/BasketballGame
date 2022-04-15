using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerOP : MonoBehaviour //Observer
{
    [SerializeField] private TextMeshProUGUI scoreCounterText = null;
    [SerializeField] private TextMeshProUGUI ballCounterText = null;

    // Start is called before the first frame update
    void Start()
    {
        //observing
        ScoreArea.OnBasketCollected += SetGoldText;
        Spawner.BallCounter += BallCounterText;
    }

    public void SetGoldText(int basketAmount) => scoreCounterText.text = basketAmount.ToString();
    public void BallCounterText(int ballAmount) => ballCounterText.text = ballAmount.ToString();
   
}
