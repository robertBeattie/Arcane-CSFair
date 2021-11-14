using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class AIController : MonoBehaviour
{
	enum Behavior { Passive, Netraul, Aggressive };
	[SerializeField] Behavior behavior;
	enum MovementBehavior { Idle, Wander, Patrol, Follow, Persue, Distance };
	[SerializeField] MovementBehavior movementBehavior;

	Movement movement;
	private void Awake() {
		movement = GetComponent<Movement>();
	}

	void Update()
    {
        
    }

	void ActionBehavior() {
		switch (behavior) {
			case Behavior.Passive:
				Debug.Log("0");
				break;
			case Behavior.Netraul:
				Debug.Log("1");
				break;
			case Behavior.Aggressive:
				Debug.Log("2");
				break;
		}
	}
}
