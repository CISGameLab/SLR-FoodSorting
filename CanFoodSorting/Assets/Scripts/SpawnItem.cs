using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSpawning
{
    public class SpawnItem : MonoBehaviour
    {
        public GameObject[] throwables;
        public GameObject currThrowable;
        public Transform spawnPos;
        int arrayCount;
        int itemToGet;

        private void Start()
        {
            arrayCount = throwables.Length - 1;
            itemToGet = Random.Range(0, arrayCount);

            currThrowable = throwables[itemToGet];

            Instantiate(currThrowable, spawnPos.transform.position, spawnPos.transform.rotation);
        }

        public void SpawnItemIn(GameObject oldItem)
        {
            oldItem.tag = "OldThrowable";
            StartCoroutine(WaitingToSpawn());
        }

        IEnumerator WaitingToSpawn()
        {
            yield return new WaitForSeconds(2);

            arrayCount = throwables.Length - 1;
            itemToGet = Random.Range(0, arrayCount);

            currThrowable = throwables[itemToGet];

            Instantiate(currThrowable, spawnPos.transform.position, spawnPos.transform.rotation);
        }
    }
}
