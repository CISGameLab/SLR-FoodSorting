using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMan : MonoBehaviour {

    public TMP_Text finalScore;
    public TMP_Text bestScore;
    public Button PlayAgain;
    public Button MainMenu;
	// Use this for initialization
	void Start ()
    {
        PlayAgain.onClick.AddListener(() => LoadGame());
        MainMenu.onClick.AddListener(() => LoadMainMenu());
        finalScore.text = "FINAL SCORE: " + PlayerPrefs.GetInt("currScore");
        bestScore.text = "BEST: " + PlayerPrefs.GetInt("highscore");
    }
	
	public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
