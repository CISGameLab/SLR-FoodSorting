using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scoring
{
    public class missed : MonoBehaviour
    {

        public GameMan main;

        void OnTriggerEnter(Collider other)
        {
            main.Missed();
        }
    }
}
