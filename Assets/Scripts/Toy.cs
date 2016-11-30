using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;

public class Toy : MonoBehaviour {

	Object toyPrefab;
	private string prefabPath = "Assets/Prefabs/Toy.prefab";
	private GameObject toy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals("Ground") && !col.gameObject.name.Equals("SlingShot")) {
			Destroy (col.gameObject);
			Destroy (this.gameObject);
		}
		if (col.gameObject.name.Equals ("Ground")) {
			Destroy (this.gameObject);
		}


	}

	void ShowToy () {
		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		//Instantiate the prefab in the scene
		GameObject toyObject = Instantiate (toyPrefab) as GameObject;
		toyObject.transform.position = transform.position;
	}

	public void createToy(){
		toy = GameObject.Find ("Toy");
		//Creates empty prefab in the prefabs folder
		Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
		//Replaces empty prefab with gameObject Toy
		PrefabUtility.ReplacePrefab (toy, prefab, ReplacePrefabOptions.ConnectToPrefab);
		toy.AddComponent<Rigidbody>();
		//GameObject body  = toy.GetComponent<Body> ();
		//body.transform.localPosition = new Vector3(0,0,0);
		toy.tag = "Toy";
		toy.transform.position = new Vector3 (0,0,0);
		SceneManager.LoadScene ("Scene_1");
	}
}
