using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scoring
{
    public class BoxTriggerManager : MonoBehaviour
    {
        public GameMan mainGame;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "OldThrowable")
            {
                Debug.Log("HERES A POINT");
            }
        }

    }
}
