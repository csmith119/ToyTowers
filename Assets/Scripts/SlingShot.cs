using UnityEngine;
using UnityEditor;
using System.Collections;
//Alex Goslen, Will Timpson, book
public class SlingShot : MonoBehaviour {
	static public SlingShot S;
	public GameObject prefabProjectile;
	public float velocityMult = 4f;

	public GameObject launchPoint;
	public Vector3 launchPos;
	public GameObject toy;
	private Object toyPrefab;
	public bool aimingMode;

	void Start(){
		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		prefabProjectile = Instantiate (toyPrefab) as GameObject;
		prefabProjectile.transform.position = new Vector3 (100,100,100);
		prefabProjectile.transform.eulerAngles = new Vector3 (0,0,0);

	}

	//Code from the Book Example
	void Update() {
		if (!aimingMode)
			return;
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		Vector3 mouseDelta = mousePos3D - launchPos;
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
				toy = null;
				MissionDemolition.ShotsFired ();
			}
		}
	}

	//Code from the Book Example
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
		toy.tag = "playerToy";
		toy.transform.position = launchPos;
		Rigidbody rb = toy.GetComponent<Rigidbody> ();
		//freezes rotation except in z direction to avoid smushing
		rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
		toy.transform.eulerAngles = new Vector3 (0,0,0);
		rb.isKinematic = true;
		toy.AddComponent(typeof(Toy));
	}

	//Creates new  player toy prefab when a new level is triggered
	public void ReStart(){
		toyPrefab = AssetDatabase.LoadAssetAtPath 
			("Assets/Prefabs/Toy.prefab", typeof(GameObject) );
		prefabProjectile = Instantiate (toyPrefab) as GameObject;
		prefabProjectile.transform.position = new Vector3 (100,100,100);

	}
}
