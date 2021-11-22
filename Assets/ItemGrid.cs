using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    const float tileSizeWidth = 32;
    const float tileSizeHeight = 32;

    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();    
    }

    Vector2 positionOnTheGrid = new Vector2();
    Vector2 tileGridPosition = new Vector2Int();

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = mousePosition.y - rectTransform.position.y;

        tileGridPosition.x = (int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnTheGrid.y / tileSizeHeight);
    }
}
