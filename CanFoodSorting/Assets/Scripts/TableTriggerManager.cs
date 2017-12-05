using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSpawning
{
    public class TableTriggerManager : MonoBehaviour
    {
        public SpawnItem newItem;

        void OnTriggerExit(Collider other)
        {
            if (other.tag == "CurrThrowable")
            {
                Debug.Log("Item Exited");
                
                newItem.SpawnItemIn(other.gameObject);
            }
        }
    }
}
