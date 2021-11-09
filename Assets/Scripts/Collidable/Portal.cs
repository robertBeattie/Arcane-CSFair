using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Portal : Collidable
{
	[SerializeField] string[] sceneNames;

	protected override void OnColide(Collider2D coll) {
		if(coll.tag == "Player") {
			//Teleport the player
			string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

		}
	}
}
