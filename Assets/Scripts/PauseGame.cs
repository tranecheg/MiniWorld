﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPause;
    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!isPause)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
           else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            isPause = !isPause;
            
        }
            
    }
}
