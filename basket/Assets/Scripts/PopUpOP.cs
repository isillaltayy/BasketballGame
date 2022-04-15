using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class PopUpOP : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button quitButton;

    [SerializeField] private TextMeshProUGUI endScorePopUpText=null;
    [SerializeField] GameObject popupMenu;

    public static bool isFinished = false;  //if true -> popUp shows up

    private int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        ScoreArea.EndBasketCollected += SetScoreText;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneLoad == 11)
            nextSceneLoad = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            ResumeGame();
        }
        else
        {
            NextLevel();
        }
    }
    public void SetScoreText(int scoreAmount) => endScorePopUpText.text = scoreAmount.ToString();
    private void ResumeGame()
    {
        popupMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void NextLevel()
    {
        popupMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitMenu()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Continue()
    {
        SceneManager.LoadScene(nextSceneLoad);
        isFinished = false;
    }
}
