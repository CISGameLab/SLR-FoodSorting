using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSpawning
{
    public class SpawnItem : MonoBehaviour
    {
        public GameObject[] throwables;
        public Transform spawnPos;

        public void SpawnItemIn(GameObject oldItem)
        {
            oldItem.tag = "OldThrowable";

            Debug.Log("Spawning Item");

            StartCoroutine(WaitingToSpawn());
            int arrayCount = throwables.Length-1;
            int itemToGet = Random.Range(0, arrayCount);
            throwables[itemToGet].tag = "CurrThrowable";
            Instantiate(throwables[itemToGet], spawnPos);
        }

        IEnumerator WaitingToSpawn()
        {
            print(Time.time);
            yield return new WaitForSeconds(5);
            print(Time.time);
        }
    }
}
