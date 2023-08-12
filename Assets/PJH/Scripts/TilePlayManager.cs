using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlayManager : Singleton<TilePlayManager>
{
    public Player _player;
    public Star[] _Stars;

    public float TileMapwidth;
    public float TileMapheight;
}
