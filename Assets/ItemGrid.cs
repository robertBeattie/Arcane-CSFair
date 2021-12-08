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

        CleanGridReference(toReturn);

        return toReturn;
    }

    private void CleanGridReference(InventoryItem item) {
        for(int ix = 0; ix < item.itemData.width; ix++) {
            for(int iy = 0; iy < item.itemData.height; iy++) {
                inventoryItemSlot[item.onGridPositionX + ix, item.onGridPositionY + iy] = null;
            }
        }
    }

    private void Init(int width, int height) {
        inventoryItemSlot = new InventoryItem[width, height];
        Vector2 size = new Vector2(width * tileSizeWidth, height * tileSizeHeight);
        rectTransform.sizeDelta = size;
    }

    internal InventoryItem GetItem(int x, int y) {
        return inventoryItemSlot[x,y];
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

    public Vector2Int? FindSpaceForObject(InventoryItem itemToInsert) {
        int height = itemToInsert.itemData.height + 1;
        int width = itemToInsert.itemData.width + 1;

        for (int y = 0; y < gridSizeHeight - height; y++) {
            for (int x = 0; x < gridSizeWidth - width; x++) {
                if (CheckAvailableSpace(x, y, itemToInsert.itemData.width, itemToInsert.itemData.height) == true) {
                    return new Vector2Int(x, y);
                }
            }
        }
        
        return null;
    }

    public bool PlaceItem(InventoryItem inventoryItem, int posX, int posY, ref InventoryItem overlapItem) {
        if(BoundaryCheck(posX, posY, inventoryItem.itemData.width, inventoryItem.itemData.height) == false) {
            return false;
        }

        if (OverlapCheck(posX, posY, inventoryItem.itemData.width, inventoryItem.itemData.height, ref overlapItem) == false) {
            overlapItem = null;
            return false;
        }

        if (overlapItem != null) {
            CleanGridReference(overlapItem);
        }

        PlaceItem(inventoryItem, posX, posY);

        return true;
    }

    public void PlaceItem(InventoryItem inventoryItem, int posX, int posY) {
        RectTransform rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(this.rectTransform);

        for(int x = 0; x < inventoryItem.itemData.width; x++) {
            for(int y = 0; y < inventoryItem.itemData.height; y++) {
                inventoryItemSlot[posX + x, posY + y] = inventoryItem;
            }    
        }
        inventoryItem.onGridPositionX = posX;
        inventoryItem.onGridPositionY = posY;

        Vector2 position = CalculatePositionOnGrid(inventoryItem, posX, posY);

        rectTransform.localPosition = position;
    }

    public Vector2 CalculatePositionOnGrid(InventoryItem inventoryItem, int posX, int posY) {
        Vector2 position = new Vector2(); //MODIFY THIS, incorrectly calculated for larger items
        position.x = posX * tileSizeWidth; //+ tileSizeWidth*inventoryItem.itemData.width/2 - tileSizeWidth/2; 
        position.y = -(posY * tileSizeHeight);// + tileSizeHeight*inventoryItem.itemData.height/2 - tileSizeHeight/2);
        return position;
    }

    private bool OverlapCheck(int posX, int posY, int width, int height, ref InventoryItem overlapItem) {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (inventoryItemSlot[posX + x, posY + y] != null) {
                    if (overlapItem == null) {
                        overlapItem = inventoryItemSlot[posX + x, posY + y];
                    } else {
                        if (overlapItem != inventoryItemSlot[posX + x, posY + y]) {
                            return false;
                        }
                    }
                }
            }
        }
        
        return true;
    }     

    private bool CheckAvailableSpace(int posX, int posY, int width, int height) {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (inventoryItemSlot[posX + x, posY + y] != null) {

                    return false;

                }
            }
        }

        return true;
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
