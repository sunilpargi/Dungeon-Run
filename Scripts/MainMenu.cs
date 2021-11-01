using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    void Start()
    {
        highScoreText.text = "HighScore : " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }
}
