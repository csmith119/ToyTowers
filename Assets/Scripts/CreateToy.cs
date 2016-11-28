﻿using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections;
//Coded by Christy Smith 
public class CreateToy : MonoBehaviour {
	//The path of where the prefab should be stored
	private string prefabPath = "Assets/Prefabs/Toy.prefab";
	private GameObject toy;

	//Takes the toy being built in create toy and stores it in a prefab
	public void createToy(){
		toy = GameObject.Find ("Toy");
		//Creates empty prefab in the prefabs folder
		Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
		//Replaces empty prefab with gameObject Toy
		PrefabUtility.ReplacePrefab (toy, prefab);
		//SceneManager.LoadScene ("Scene_1");
	}
}
