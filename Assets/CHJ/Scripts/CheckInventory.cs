using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInventory : MonoBehaviour
{
    [SerializeField] private 
     GameObject GotoNext;
    void Update()
    {
        if (AreAllChildrenInactive(gameObject))
        {

            GotoNext.SetActive(true);
        }
    }
    bool AreAllChildrenInactive(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeInHierarchy)
                return false;
        }
        return true;
    }

}
