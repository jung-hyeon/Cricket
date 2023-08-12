using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    TurnRight,
    TurnLeft,
    GoStraight,
    Empty,
}

public abstract class Tile : MonoBehaviour
{
    [SerializeField] private Sprite[] tileImages;

    private TileType tileType;
    private SpriteRenderer spriteRenderer;

    public void Setup(TileType tileType)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        TileType = tileType;
    }

    public TileType TileType
    {
        set 
        {
            tileType = value;
            spriteRenderer.sprite = tileImages[(int)tileType];
        }
        get => tileType;
    }

    public abstract void TilePlay();
}
