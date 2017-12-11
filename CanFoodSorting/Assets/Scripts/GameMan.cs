using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scoring
{
    public class GameMan : MonoBehaviour
    {

        public int currScore;
        public int streakMult;
        public int highScore;
        public Text scoreText;
        public Text streakText;
        public float timeLeft;
        // Use this for initialization
        void Start()
        {
            timeLeft = 2f;
            currScore += 0;
            streakMult = 1;
            scoreText.text = "Score: " + currScore;
            streakText.text = "Multiplier: X " + streakMult;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateScore(bool shouldGive)
        {
            if (shouldGive == true)
            {
                currScore += 100*streakMult;
                streakMult++;

            }
            else
            {
                currScore -= 100;
                streakMult = 1;
            }

            scoreText.text = "Score: " + currScore;
            streakText.text = "Multiplier: X " + streakMult;

        }

        public void Missed()
        {
            streakMult = 1;
            streakText.text = "Multiplier: X " + streakMult;
        }
    }
}
