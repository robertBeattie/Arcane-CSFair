using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class AIController : MonoBehaviour
{
	/*
		Passive does not fight back
		Neutral fights back once provoked
		Aggressive fights with out being provoked 
	*/
	enum AggressionBehavior { Passive, Neutral, Aggressive };
	[SerializeField] AggressionBehavior aggressionBehavior;

	/**
		Idle stand around
		Wander randomly move around home postion by some radius
		Patrol move betweem points in a list
		Follow follow behind Transform by some distance
		Persue Melee attacker, run after Transform
		Flee Run from Transform
		Distance Ranged attacker, trying to keep distance from Transform
	*/
	enum MovementBehavior { Idle, Wander, Patrol, Follow, Persue, Flee, Distance };
	[SerializeField] MovementBehavior movementBehavior;

	/*
		Solo does not call for help from other characters around them
		Local calls for help from characters near them in some range
		Global calls for help from characters not local to them making them aggressive 
			when a user leaves the scene
	*/
	enum MobBehavior {Solo, Local, Global};
	[SerializeField] MobBehavior mobBehavior;

	Movement movement;
	private void Awake() {
		movement = GetComponent<Movement>();
	}

	void Update()
    {
        
    }

	void ActionBehavior() {
		switch (aggressionBehavior) {
			case AggressionBehavior.Passive:
				Debug.Log("0");
				break;
			case AggressionBehavior.Neutral:
				Debug.Log("1");
				break;
			case AggressionBehavior.Aggressive:
				Debug.Log("2");
				break;
		}
	}
}
