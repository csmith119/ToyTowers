using UnityEngine;
using UnityEditor;
using System.Collections;
//Alex Goslen, Will Timpson
public class EnemyAI : MonoBehaviour {


	public GameObject projectile;
	public GameObject prefabProjectile;
	public float velocityMult = 4f;
	private Object toyPrefab;

	public GameObject launchPoint;
	public Vector3 launchPos;
	public float chanceToShoot = 0.1f;
	public float speed = 6.2f;
	public Vector3 projPos;
	public float secondsBetweenShot = 1f;
	public int divValue = 200;
	public float randomWidth;
	// Use this for initialization
	void Start () {
		launchPos = new Vector3 (9f, -8f, 0); 
		//calls shoot method every 5 seconds
		InvokeRepeating ("Shoot", 2f, secondsBetweenShot);
		//finds a semi-random arcwidth for shooting
		//randomWidth = Mathf.Clamp (Random.value * divValue, divValue-50, divValue+50);
		randomWidth = Random.value * divValue;

		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		prefabProjectile = Instantiate (toyPrefab) as GameObject;

		prefabProjectile.transform.position = new Vector3 (100,100,100);

	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate() {
	}

	//Called every 3 seconds and sets values for the new enemy toy
	private void Shoot(){
		//instantiates projectile
		projectile =  Instantiate (prefabProjectile) as  GameObject;
		projectile.tag = "enemyToy";
		Rigidbody rb = projectile.GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
		projectile.AddComponent(typeof(Toy));
		projectile.transform.eulerAngles = new Vector3 (0,0,0);
		projPos = launchPos;
		projectile.transform.position = projPos;
		//sets physics for Rigidbody
		projectile.GetComponent<Rigidbody>().isKinematic = false;
		projectile.GetComponent<Rigidbody> ().velocity = launchPos * velocityMult;
	}

	//Creates new enemy toy prefab when a new level is triggered
	public void ReStart(){
		launchPos = new Vector3 (9f, -8f, 0); 
		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		prefabProjectile = Instantiate (toyPrefab) as GameObject;
		prefabProjectile.transform.position = new Vector3 (100,100,100);
	
	}
}
