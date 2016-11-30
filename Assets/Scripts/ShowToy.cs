using UnityEngine;
using UnityEditor;
using System.Collections;
//Coded by Christy Smith
public class ShowToy : MonoBehaviour {
	Object toyPrefab;
	// Use this for initialization
	void Start () {
		//Finds toy prefab and makes it available to script
		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		//Instantiate the prefab in the scene
		GameObject toyObject = Instantiate (toyPrefab) as GameObject;
		toyObject.transform.position = transform.position;
	}

}
