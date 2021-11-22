using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* why cant I see this named in unity component? */
public class InventoryController : MonoBehaviour {
    [HideInInspector]
    public ItemGrid selectedItemGrid;

    private void Update() {
        if (selectedItemGrid == null) { return; }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(selectedItemGrid.GetTileGridPosition(Input.mousePosition));
        }
    }
}
