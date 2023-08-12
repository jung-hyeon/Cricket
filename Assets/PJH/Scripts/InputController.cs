using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private TileType currentTileType = TileType.Empty; // 마우스 클릭된 위치의 타일을 currentType 속성으로 변경

    private void Update()
    {
        RaycastHit hit;
        // 마우스 왼쪽 버튼을 누르고 있을 때
        if (Input.GetMouseButton(0))
        {
            // 카메라로부터 현재 마우스 위치로 뻗어 나가는 광선 생성
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // 광선에 부딪힌 오브젝트가 존재하면 hit에 저장
           if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 이때 hit 오브젝트에 Tile컴포넌트가 없으면 null 반환
                Tile tile = hit.transform.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.TileType = currentTileType;
                }
            }
        }
    }

    public void SetTileType(int tileType)
    {
        currentTileType = (TileType)tileType;
    }
}
