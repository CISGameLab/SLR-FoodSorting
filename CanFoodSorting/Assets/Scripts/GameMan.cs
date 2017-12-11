using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scoring
{
    public class GameMan : MonoBehaviour
    {

        public int currScore;
        public int highScore;
        public Text scoreText;

        // Use this for initialization
        void Start()
        {
            currScore += 0;
            scoreText.text = "Score: " + currScore;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateScore()
        {
            currScore += 100;
            scoreText.text = "Score: " + currScore;
        }
    }
}
