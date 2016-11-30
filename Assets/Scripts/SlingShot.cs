using UnityEngine;
using UnityEditor;
using System.Collections;

public class SlingShot : MonoBehaviour {
	static public SlingShot S;
	public GameObject prefabProjectile;
	public float velocityMult = 4f;
	public bool _____________________;

	public GameObject launchPoint;
	public Vector3 launchPos;
	public GameObject toy;
	private Object toyPrefab;
	public bool aimingMode;

	void Start(){
		//GameObject toy = 
		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		//prefabProjectile = toyPrefab;
		prefabProjectile = Instantiate (toyPrefab) as GameObject;

//
		prefabProjectile.transform.position = new Vector3 (100,100,100);
		prefabProjectile.transform.eulerAngles = new Vector3 (0,0,0);
//
//		prefabProjectile.AddComponent<Rigidbody>();
//		prefabProjectile.tag = "Toy";
//
//		toy.GetComponent<Rigidbody>().isKinematic = true;
//		toy.GetComponent<Rigidbody> ().useGravity = false;
//		toy = prefabProjectile;
	}

	void Update() {
		if (!aimingMode)
			return;
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		Vector3 mouseDelta = mousePos3D - launchPos;
//		Debug.Log ("mouse pos " + mousePos3D);
//		Debug.Log ("launch pos " + launchPos);
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;
		if (mouseDelta.magnitude > maxMagnitude){
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}
		Vector3 projPos = launchPos + mouseDelta;
		if (toy != null) {
			toy.transform.position = projPos;
		
			if (Input.GetMouseButtonUp (0)) {
				aimingMode = false;
				toy.GetComponent<Rigidbody>().isKinematic = false;
				toy.GetComponent<Rigidbody> ().velocity = -mouseDelta * velocityMult;
	//			Debug.Log (" player projectile mouseDelta" + mouseDelta);
				//FollowCam.S.poi = projectile;
				toy = null;
				MissionDemolition.ShotsFired ();
			}
		}
	}

	void Awake(){
		S = this;
		Transform launchingPointTrans = transform.Find ("LaunchPoint");
		launchPoint = launchingPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchingPointTrans.position;
	}

	void OnMouseEnter() {
		//print ("Slingshot:OnMouseEnter()");
		launchPoint.SetActive(true);
	}

	void OnMouseExit() {
		//print ("Slingshot:OnMouseExit()");
		launchPoint.SetActive(false);
	}
	void OnMouseDown(){
		aimingMode = true;
		toy = Instantiate (prefabProjectile) as GameObject;
		toy.transform.position = launchPos;
		Rigidbody rb = toy.GetComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		toy.transform.eulerAngles = new Vector3 (0,0,0);
		//rb.constraints = RigidbodyConstraints.FreezeRotationY;
		rb.isKinematic = true;
		toy.AddComponent(typeof(Toy));
	}
}
