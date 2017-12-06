using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerManager : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CurrThrowable")
        {
            Debug.Log("HERES A POINT");
        }
    }

}
