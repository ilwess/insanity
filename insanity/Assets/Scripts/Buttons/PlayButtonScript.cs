﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Game");
    }
}
