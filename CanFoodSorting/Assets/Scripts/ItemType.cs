using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour {

    public string itemType;

    public void SetType(string type)
    {
        itemType = type;
    }

    public new string GetType()
    {
        return itemType;
    }
}
