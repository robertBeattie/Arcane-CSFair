using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    public const float tileSizeWidth = 32;
    public const float tileSizeHeight = 32;

    InventoryItem[,] inventoryItemSlot;

    RectTransform rectTransform;

    [SerializeField] int gridSizeWidth = 20;
    [SerializeField] int gridSizeHeight = 10;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();    
        Init(gridSizeWidth, gridSizeHeight);
    }


    public InventoryItem PickUpItem(int x, int y) {
        InventoryItem toReturn = inventoryItemSlot[x, y];

        if (toReturn == null) { return null; }

        for(int ix = 0; ix < toReturn.itemData.width; ix++) {
            for(int iy = 0; iy < toReturn.itemData.height; iy++) {
                inventoryItemSlot[toReturn.onGridPositionX + ix, toReturn.onGridPositionY + iy] = null;
            }
        }
        return toReturn;
    }

    private void Init(int width, int height) {
        inventoryItemSlot = new InventoryItem[width, height];
        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;
    }

    Vector2 positionOnTheGrid = new Vector2();
    Vector2Int tileGridPosition = new Vector2Int();

    public Vector2Int GetTileGridPosition(Vector2 mousePosition) {
        positionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        positionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(positionOnTheGrid.x / tileSizeWidth);
        tileGridPosition.y = (int)(positionOnTheGrid.y / tileSizeHeight);

        return tileGridPosition;
    }

    public void PlaceItem(InventoryItem inventoryItem, int posX, int posY) {
        if(BoundaryCheck(posX, posY, inventoryItem.itemData.width, inventoryItem.itemData.height) == false) {
            return;
        }

        RectTransform rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(this.rectTransform);

        for(int x = 0; x < inventoryItem.itemData.width; x++) {
            for(int y = 0; y < inventoryItem.itemData.height; y++) {
                inventoryItemSlot[posX + x, posY + y] = inventoryItem;
            }    
        }
        inventoryItem.onGridPositionX = posX;
        inventoryItem.onGridPositionY = posY;

        Vector2 position = new Vector2();
        position.x = posX * tileSizeWidth; //+ tileSizeWidth*inventoryItem.itemData.width/2 - tileSizeWidth/2; //not sure why need itemData here, but it seems to work fine?
        position.y = -(posY * tileSizeHeight);// + tileSizeHeight*inventoryItem.itemData.height/2 - tileSizeHeight/2);

        rectTransform.localPosition = position;
    }

    bool PositionCheck(int posX, int posY) {
        if(posX < 0 || posY < 0) {
            return false;
        }

        if (posX >= gridSizeWidth || posY >= gridSizeHeight) {
            return false;
        }
        return true;
    }

    bool BoundaryCheck(int posX, int posY, int width, int height) {
            if (PositionCheck(posX, posY) == false) { return false; }

            posX += width - 1;
            posY += height - 1;

            if (PositionCheck(posX, posY) == false) { return false; }

        return true;
    }
}
