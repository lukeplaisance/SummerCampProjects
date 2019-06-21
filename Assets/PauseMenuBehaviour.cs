using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        OpenPauseMenu();
    }

    public void OpenPauseMenu()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            panel.gameObject.SetActive(true);
            if(Time.timeScale == 1.0)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
