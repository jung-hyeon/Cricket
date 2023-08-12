using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private TileType currentTileType = TileType.Empty; // ���콺 Ŭ���� ��ġ�� Ÿ���� currentType �Ӽ����� ����

    private void Update()
    {
        RaycastHit hit;
        // ���콺 ���� ��ư�� ������ ���� ��
        if (Input.GetMouseButton(0))
        {
            // ī�޶�κ��� ���� ���콺 ��ġ�� ���� ������ ���� ����
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // ������ �ε��� ������Ʈ�� �����ϸ� hit�� ����
           if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // �̶� hit ������Ʈ�� Tile������Ʈ�� ������ null ��ȯ
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
