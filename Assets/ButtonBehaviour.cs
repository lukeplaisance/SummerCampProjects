using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject panel;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("0.Main");
    }

    public void ResumeGame()
    {
        panel.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
