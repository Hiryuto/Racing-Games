using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    //指定したcanvasを非表示にする準備
    public Canvas pauseCanvas;
    public Canvas statusCanvas;
    void Start()
    {
        //指定したcanvasを非表示にする
        pauseCanvas.enabled = false;
        statusCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        keyPressed();
    }

    public void keyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause");
            clickEvent();
        }
    }
    public void clickEvent()
    {
        Debug.Log("click");
        if (Time.timeScale == 1)
        {
            PauseGame();
        }
        else if (Time.timeScale == 0)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        statusCanvas.enabled = true;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.enabled = true;
        statusCanvas.enabled = false;
    }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

}