using UnityEngine;
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
		toy.tag = "Toy";

		//Toy t = toy.AddComponent <Toy>() as Toy;
//		SlingShot ss = GameObject.Find("SlingShot").GetComponent<SlingShot>();
//		ss.prefabProjectile = toy;

		SceneManager.LoadScene ("Scene_1");
	}
}
