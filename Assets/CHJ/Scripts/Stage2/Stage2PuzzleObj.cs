using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Stage2PuzzleObj : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;
    private Vector3 originalPosition;
    private int stage2GoalScore=0;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {

            if (result.gameObject != this.gameObject)
            {
                //Debug.Log("탐지된 오브젝트: " + result.gameObject.name + ", 태그: " + result.gameObject.tag);
                if (result.gameObject.tag == this.gameObject.tag)
                {
                    Image img = result.gameObject.GetComponent<Image>();
                    if (img)
                    {
                        Color currentColor = img.color;
                        currentColor.a = 1f;  // 알파값을 1 (255의 정규화된 값)로 설정
                        img.color = currentColor;
                        
                    }
                }
            }
        }
        

        transform.position = originalPosition; 
    }
    
}