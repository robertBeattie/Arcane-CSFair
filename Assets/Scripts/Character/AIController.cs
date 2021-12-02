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
	[SerializeField] Transform target;
	[SerializeField] Transform hand;
	[SerializeField] Weapon weapon;
	Movement movement;
	private void Awake() {
		movement = GetComponent<Movement>();
		hand = transform.GetChild(0).transform;
		weapon = hand.GetChild(0).GetComponent<Weapon>();
		if(target == null){
			target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
		}

	}

	void Update()
    {
        ActionBehavior();
    }

	void ActionBehavior() {
		switch (aggressionBehavior) {
			case AggressionBehavior.Passive:
				RunFrom(target);
				break;
			case AggressionBehavior.Neutral:
				Debug.Log("1");
				break;
			case AggressionBehavior.Aggressive:
				MoveTowards(target);
				break;
		}
	}


	void MoveTowards(Transform target){
		//chace after target
		//Transform target;
		float aggroRange = 7f;

		Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
		Vector2 targetPos = new Vector2(target.position.x,target.position.y);
		if(Vector2.Distance(myPos, targetPos) <= aggroRange){
			Vector3 moveVector = (target.position - transform.position).normalized;
			movement.Move(moveVector);
		}
	}

	void RunFrom(Transform targt){
		float fleeRange = 7f;

		Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
		Vector2 targetPos = new Vector2(target.position.x,target.position.y);
		if(Vector2.Distance(myPos, targetPos) <= fleeRange){
			Vector3 moveVector = (transform.position - target.position).normalized;
			movement.Move(moveVector);
		}
	}

	void Attack(){
		if (weapon == null) return;

		//aim towards target

		//if within weapon range 
		//     then attack
	}
}
