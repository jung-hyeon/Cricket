using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTile : Tile
{
    override public void TilePlay()
    {
        TilePlayManager.instance._player.PlayEmpty();
    }
}
