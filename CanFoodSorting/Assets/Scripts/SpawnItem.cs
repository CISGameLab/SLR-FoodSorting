using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSpawning
{
    public class SpawnItem : MonoBehaviour
    {
        public GameObject[] throwables;
        public string[] itemTypes;
        public GameObject currThrowable;
        public Transform spawnPos;
        int arrayCount;
        int itemToGet;

        private void Start()
        {
            Place();
        }

        public void SpawnItemIn(GameObject oldItem)
        {
            oldItem.tag = "OldThrowable";
            StartCoroutine(WaitingToSpawn());
        }

        IEnumerator WaitingToSpawn()
        {
            yield return new WaitForSeconds(2);
            Place();
        }

        public void Place()
        {
            arrayCount = throwables.Length;
            itemToGet = Random.Range(0, arrayCount);
            currThrowable = throwables[itemToGet];
            currThrowable.GetComponent<ItemType>().SetType(itemTypes[itemToGet]);

            Instantiate(currThrowable, spawnPos.transform.position, currThrowable.transform.rotation);
        }
    }
}
