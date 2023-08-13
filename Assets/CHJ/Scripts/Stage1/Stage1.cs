using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Stage1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;
    private Vector3 originalPosition;
    private int stage1GoalScore = 0;

    [SerializeField]
    private GameObject Stage1PuzzlePopUp;
    [SerializeField]
    private GameObject PuzzlePopUp2;
    [SerializeField]
    private GameObject GoBtn;

    public void SetTrueButton()
    {
        GoBtn.SetActive(true);
    }
    public void GotoPopup2()
    {
        PuzzlePopUp2.SetActive(true);

    }
    public void ClickBack()
    {
        Stage1PuzzlePopUp.SetActive(false);

    }
    public void ClickBack2()
    {
        Stage1PuzzlePopUp.SetActive(false);

    }

    void Awake()
    {
        Stage1PuzzlePopUp.SetActive(true);
        PuzzlePopUp2.SetActive(false);
        
    }


    private void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        

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
                        stage1GoalScore++;
                        Debug.Log(stage1GoalScore);
                        
                    }
                }
            }
        }


        transform.position = originalPosition;

    }

}