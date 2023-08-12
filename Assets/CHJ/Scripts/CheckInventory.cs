using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInventory : MonoBehaviour
{
    [SerializeField] private GameObject RobozlePopup1;
    void Update()
    {
        if (AreAllChildrenInactive(gameObject))
        {

            RobozlePopup1.SetActive(true);
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
