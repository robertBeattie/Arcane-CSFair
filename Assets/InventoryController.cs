using System.Collections.Generic;
using UnityEngine;

/* why cant I see this named in unity component? */
public class InventoryController : MonoBehaviour {
    [HideInInspector]
    public ItemGrid selectedItemGrid;

    InventoryItem selectedItem;
    InventoryItem overlapItem;
    RectTransform rectTransform;

    [SerializeField] List<ItemData> items;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject groundItemPrefab;
    [SerializeField] Transform canvasTransform;

    InventoryHighlight inventoryHighlight;

    private void Awake() {
        inventoryHighlight = GetComponent<InventoryHighlight>();
    }

    private void Update() {
        ItemIconDrag();

        if(Input.GetKeyDown(KeyCode.Q)) {
            if (selectedItem == null) {
                CreateRandomItem();
            }
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            InsertRandomItem();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            int selectedItemID = UnityEngine.Random.Range(0, items.Count);
            DropItemToGround(items[selectedItemID]);
        }

        if (selectedItemGrid == null) { return; }

        //HandleHighlight();

        if (Input.GetMouseButtonDown(0)) {
            LeftMouseButtonPress();
        }
    }

    private void InsertRandomItem() {
        if (selectedItemGrid == null) { return; }

        CreateRandomItem();
        InventoryItem itemToInsert = selectedItem;
        selectedItem = null;
        InsertItem(itemToInsert);
    }
    public void AddFromGroundToInventory(ItemData itemData){
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;        
        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);
        rectTransform.SetAsLastSibling();

        inventoryItem.Set(itemData);

        InventoryItem itemToInsert = selectedItem;
        selectedItem = null;
        InsertItem(itemToInsert);
        
    }

    public void DropItemToGround(ItemData itemData){
        System.Random random = new System.Random();
        // rand 0.0-1.0 * (max - min) + min
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        float x = playerTransform.position.x + (float)((random.NextDouble() + -.5f) * (2 - 0) + 1);
        float y = playerTransform.position.y + (float)((random.NextDouble() + -.5f) * (2 - 0) + 1);
        Vector3 pos = new Vector3(x,  y, 0);
        GameObject n = Instantiate(groundItemPrefab, pos, Quaternion.identity);
        groundItemPrefab.GetComponent<PickUpItem>().setItemData(itemData);
        groundItemPrefab.GetComponentInChildren<SpriteRenderer>().sprite = itemData.itemIcon;
    }

    public void InsertItem(InventoryItem itemToInsert) {
        Vector2Int? posOnGrid = selectedItemGrid.FindSpaceForObject(itemToInsert);

        if (posOnGrid == null) { return; }

        selectedItemGrid.PlaceItem(itemToInsert, posOnGrid.Value.x, posOnGrid.Value.y);
    }

// TODO: finish highlighting by calcualting grid position correctly
// TODO: stop highlighting after cursor moved away 1:27:20
    //InventoryItem itemToHighlight;

    // private void HandleHighlight() {
    //     Vector2Int positionOnGrid = GetTileGridPosition();
    //     if (selectedItem == null) {
    //         itemToHighlight = selectedItemGrid.GetItem(positionOnGrid.x, positionOnGrid.y);

    //         if (itemToHighlight != null) {
    //             inventoryHighlight.SetSize(itemToHighlight);
    //             inventoryHighlight.SetPosition(selectedItemGrid, itemToHighlight);
    //         }
    //     } else {

    //     }
    // }

    private void CreateRandomItem() {
        InventoryItem inventoryItem = Instantiate(itemPrefab).GetComponent<InventoryItem>();
        selectedItem = inventoryItem;        
        rectTransform = inventoryItem.GetComponent<RectTransform>();
        rectTransform.SetParent(canvasTransform);
        rectTransform.SetAsLastSibling();


        int selectedItemID = UnityEngine.Random.Range(0, items.Count);
        inventoryItem.Set(items[selectedItemID]);
    }

    private void LeftMouseButtonPress() {
        Vector2Int tileGridPosition = GetTileGridPosition();

        if (selectedItem == null) {
            PickUpItem(tileGridPosition);
        } else {
            PlaceItem(tileGridPosition);
        }
    }

    private Vector2Int GetTileGridPosition() {
        Vector2 position = Input.mousePosition;

        if(selectedItem != null) {
            position.x -= (selectedItem.itemData.width - 1) * ItemGrid.tileSizeWidth; // MODIFY to fix offset of mouse holding item
            position.y += (selectedItem.itemData.height - 1) * ItemGrid.tileSizeHeight;
        }

        return selectedItemGrid.GetTileGridPosition(position);
    }

    private void ItemIconDrag() {
        if (selectedItem != null) {
            rectTransform.position = Input.mousePosition;
        }
    }

    private void PickUpItem(Vector2Int tileGridPosition) {
        selectedItem = selectedItemGrid.PickUpItem(tileGridPosition.x, tileGridPosition.y);
        if (selectedItem!=null) {
            rectTransform = selectedItem.GetComponent<RectTransform>();
        }
    }

    private void PlaceItem(Vector2Int tileGridPosition) {
        bool complete = selectedItemGrid.PlaceItem(selectedItem, tileGridPosition.x, tileGridPosition.y, ref overlapItem);
        if (complete) {
            selectedItem = null;
            if(overlapItem != null) {
                selectedItem = overlapItem;
                overlapItem = null;
                rectTransform = selectedItem.GetComponent<RectTransform>();
                rectTransform.SetAsLastSibling();
            }
        }
    }
}
