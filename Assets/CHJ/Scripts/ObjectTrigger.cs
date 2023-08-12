using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.tag == "Player")
            {
                Debug.Log("충돌");
                
                BlinkEffect blinkEffect = gameObject.GetComponent<BlinkEffect>();
                blinkEffect.StartBlinking(2.0f, 0.25f); // 5초 동안 투명도가 50%에서 100% 사이에서 변화
            }
        
    }
}
