using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    PlayerMovement movement;
    GameObject inventory;
    [SerializeField] Hand hand;
    [SerializeField] Weapon weapon;
    void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("PlayerInventory");
        movement = GetComponent<PlayerMovement>();
        if (weapon == null) weapon = GetComponentInChildren<Weapon>();
    }

	private void Update() {
        MouseInput();
        AttackInput();
        ToggleUI();
    }

	void FixedUpdate()
    {
        MovementInput();
    }

    void ToggleUI() {
        if (Input.GetKeyDown(KeyCode.I)) {
            inventory.SetActive(!inventory.activeSelf);
        }
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
		if (Input.GetButton("Fire1")) {
            //anim.Play("SwordSwing");
            weapon.Attack();
        }
	}

    void SkillInput() {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log("Skill 1");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            Debug.Log("Skill 2");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            Debug.Log("Skill 3");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            Debug.Log("Skill 4");
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            Debug.Log("Skill 5");
        }
    }

}
