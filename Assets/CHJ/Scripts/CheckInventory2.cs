using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInventory2 : MonoBehaviour
{
    [SerializeField]
    private GameObject GotoNext;
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
