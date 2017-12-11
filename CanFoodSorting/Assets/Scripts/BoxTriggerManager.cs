using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scoring
{
    public class BoxTriggerManager : MonoBehaviour
    {
        public GameMan mainGame;
        public string ItemType;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "OldThrowable")
            {
                if (other.gameObject.GetComponent<ItemType>().GetType() == ItemType)
                {
                    Debug.Log("HERES A POINT");
                    mainGame.UpdateScore(true);
                }
                else
                {
                    Debug.Log("GIMME DAT POINT");
                    mainGame.UpdateScore(false);
                }
            }
        }

    }
}
