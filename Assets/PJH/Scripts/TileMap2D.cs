using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap2D : MonoBehaviour
{
    public float width;
    public float height;

    [SerializeField] private GameObject tilePrefab;

    private float yOffset = -4.5f; // y�� �����Ǵ� ��ġ

    private void Awake()
    {
        GenerateTilemap();
    }

    private void GenerateTilemap()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x< width; x++)
            {
                Vector3 position = new Vector3((-width*0.5f+0.5f)+x, (height*0.5f+0.5f+ yOffset) -y, 0);
                SpawnTile(TileType.Empty, position);
            }
        }
    }
    
    private void SpawnTile(TileType tileType, Vector3 position)
    {
        GameObject clone = Instantiate(tilePrefab, position, Quaternion.identity);
        clone.transform.SetParent(transform);

        Tile tile = clone.GetComponent<Tile>();
        tile.Setup(tileType);
    }

    public void PlayTileMap()
    {
        // �ڽ� ������Ʈ�� ���ʷ� �����ϸ鼭 .TilePlay()
    }

}
