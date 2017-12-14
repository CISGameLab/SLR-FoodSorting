using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace Scoring
{
    public class GameMan : MonoBehaviour
    {

        public int currScore;
        public int streakMult;
        public int highScore;
        public string highscoreKey;
        public string currscoreKey;
        public TMP_Text scoreText;
        public TMP_Text streakText;
        public TMP_Text highscoreText;
        public TMP_Text timeLeftText;
        public float timeLeft;
        bool highscoreExists;
        private bool redFont;
        private bool flashing;

        // Use this for initialization
        void Start()
        {
            redFont = false;
            flashing = false;
            timeLeftText.color = new Color32(0, 0, 0, 255);
            timeLeft = 120f;
            currScore += 0;
            streakMult = 1;
            scoreText.text = "SCORE: " + currScore;
            streakText.text = "MULTIPLIER: X " + streakMult;
            highscoreKey = "highscore";
            currscoreKey = "currScore";
            highscoreExists = PlayerPrefs.HasKey(highscoreKey);
            highScore = 0;
            PlayerPrefs.SetInt(currscoreKey, 0);

            if (highscoreExists)
            {
                highScore = PlayerPrefs.GetInt(highscoreKey);

                if (highScore < currScore)
                {
                    PlayerPrefs.SetInt(highscoreKey, currScore);
                    highScore = currScore;

                    PlayerPrefs.Save();
                }
                highscoreText.text = "HIGHSCORE: " + highScore.ToString();
            }
            else
            {
                PlayerPrefs.SetInt(highscoreKey, 0);
                highscoreText.text = "HIGHSCORE: " + highScore.ToString();
            }
        }

        // Update is called once per frame
        void Update()
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.text = "TIME LEFT: " + timeLeft.ToString("F1") + " secs";

            if (timeLeft <= 0)
            {
                EndGame();
            }
            else if (timeLeft <= 30f && redFont == false)
            {
                redFont = true;
                timeLeftText.color = new Color32(255, 0, 0, 255);
            }

            if(timeLeft<=10f && flashing == false)
            {
                flashing = true;
                StartCoroutine(FlashingText());
            }

            if (highScore < currScore)
            {
                PlayerPrefs.SetInt(highscoreKey, currScore);
                highScore = currScore;
                highscoreText.text = "HIGHSCORE: " + highScore.ToString();
                PlayerPrefs.Save();
            }
        }

        public void UpdateScore(bool shouldGive)
        {
            if (shouldGive == true)
            {
                currScore += 100 * streakMult;
                streakMult++;

            }
            else
            {
                currScore -= 100;
                streakMult = 1;
            }

            scoreText.text = "SCORE: " + currScore;
            streakText.text = "MULTIPLIER: X " + streakMult;

        }

        public void Missed()
        {
            streakMult = 1;
            streakText.text = "MULTIPLIER: X " + streakMult;
        }

        public void EndGame()
        {
            if (highScore < currScore)
            {
                PlayerPrefs.SetInt(highscoreKey, currScore);
                highScore = currScore;
                highscoreText.text = "HIGHSCORE: " + highScore.ToString();

            }
            PlayerPrefs.SetInt(currscoreKey, currScore);
            PlayerPrefs.Save();

            SceneManager.LoadScene("EndGame");
        }

        //Blinking Text
        public IEnumerator FlashingText()
        {
            while (true)
            {
                timeLeftText.gameObject.SetActive(false);
                yield return new WaitForSeconds(.35f);
                timeLeftText.gameObject.SetActive(true);
                yield return new WaitForSeconds(.35f);
            }
        }
    }
}
