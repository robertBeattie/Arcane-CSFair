using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    
    void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    public void Move(Vector3 moveDelta) {
        FlipSprite(moveDelta);

        //Collision Detection
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking", "Character"));
        if(hit.collider == null) {
            //move transform up and down
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
		} 
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking", "Character"));
        if (hit.collider == null) {
            //move transform right and left
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        } 

    }

    public void FlipSprite(Vector3 moveDelta) {
        //Swap Sprite direction, wether its going right or left
        if (moveDelta.x < 0) {
            transform.localScale = Vector3.one;
        } else if (moveDelta.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
