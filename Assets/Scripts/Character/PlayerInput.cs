using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    PlayerMovement movement;
    [SerializeField] Hand hand;
    [SerializeField] Animation anim;
    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

	private void Update() {
        MouseInput();
        AttackInput();
    }

	void FixedUpdate()
    {
        MovementInput();
    }


    void MovementInput() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 moveDelta = new Vector3(x, y, 0);
        // magic number is speed multiplyer
        movement.Move(moveDelta * 4);
    }

    void MouseInput() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hand.UpdateHand(mousePos, transform.position);

        if (transform.position.x > mousePos.x) {
            transform.localScale = Vector3.one;
        } else if (transform.position.x < mousePos.x) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void AttackInput() {
		if (Input.GetButtonDown("Fire1")) {
            //anim.Play("SwordSwing");
        }
	}

    void SkillInput() {

    }

}
