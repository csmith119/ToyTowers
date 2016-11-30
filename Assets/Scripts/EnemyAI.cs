using UnityEngine;
using UnityEditor;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	public GameObject projectile;
	public GameObject prefabProjectile;
	public float velocityMult = 4f;
	private Object toyPrefab;

	public GameObject launchPoint;
	public Vector3 launchPos;
	//public GameObject projectile;
	public float chanceToShoot = 0.1f;
	public float speed = 6.2f;
	public Vector3 projPos;
	public float secondsBetweenShot = 7f;
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
		//prefabProjectile = toyPrefab;
		prefabProjectile = Instantiate (toyPrefab) as GameObject;

		//
		prefabProjectile.transform.position = new Vector3 (100,100,100);
//		Debug.Log ("random width" + randomWidth);

	}
	
	// Update is called once per frame
	void Update () {
		//move in the negative x direction with respect to time
		float deltaX = -speed * Time.deltaTime;
		projPos.x += deltaX;
		//Debug.Log ("enemy proj x " + projPos.x);
//		Debug.Log ("random width" + randomWidth);
		//change y like a parabola, y=x^2/divVale + height
		projPos.y = -(((projPos.x-deltaX) * (projPos.x-deltaX))/randomWidth)+4;
		projPos.z = 0;
		if (projectile != null) {
			projectile.transform.position = projPos;
		}

	}

	void FixedUpdate() {
	}

	private void Shoot(){
		//instantiates projectile
	//	Destroy(projectile);
		projectile = Instantiate (prefabProjectile) as GameObject;
		Rigidbody rb = projectile.GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
		projectile.AddComponent(typeof(Toy));
		projectile.transform.eulerAngles = new Vector3 (0,0,0);
		//Debug.Log ("proj mass = " + projectile.GetComponent<Rigidbody> ().mass);
	//	projectile.GetComponent<Rigidbody>().mass = 1;
		projPos = launchPos;
		projectile.transform.position = projPos;
		//sets physics for Rigidbody
		projectile.GetComponent<Rigidbody>().isKinematic = false;
//		projectile.GetComponent<Rigidbody> ().velocity = launchPos * velocityMult;
		//finds a semi-random arcwidth for shooting
		//randomWidth = Mathf.Clamp (Random.value * divValue, divValue-50, divValue+50);

		randomWidth = Random.value * divValue;
//		Debug.Log ("random width" + randomWidth);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Equals ("Ground")){
			Destroy(this.gameObject);
		}
	}
}
