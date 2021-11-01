using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
   
    public Text scoreText;
    private bool isShowned;
    public Image backgroundImg;
    private float transition;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowned)
            return;

        transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Vector4(0, 0, 0, 0), Color.black, transition);
    }

    public void ToggelEndMenu(float _scoreValue)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)_scoreValue).ToString();
        isShowned = true; 
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }
}
