using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public void CallDestroy(GameObject item)
    {
        StartCoroutine(DestroyItem(item));
    }


    public IEnumerator DestroyItem(GameObject item)
    {
        yield return new WaitForSeconds(20);
        Destroy(item);
    }

}
