using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSpawning
{
    public class TableTriggerManager : MonoBehaviour
    {
        public SpawnItem newItem;
        public DestroyObjects dest;

        void OnTriggerExit(Collider other)
        {
            if (other.tag == "CurrThrowable")
            {                 
                newItem.SpawnItemIn(other.gameObject);
                dest.CallDestroy(other.gameObject);
            }
        }
    }
}
