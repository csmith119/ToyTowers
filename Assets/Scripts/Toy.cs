using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.SceneManagement;
//Alex Goslen, Will Timpson
public class Toy : MonoBehaviour  {


	private float speed = 12.4f;
	private Vector3 projPos;
	public int divValue;
	private float randomWidth;
	public float range;
	private int changeInScore = 10;
	public int playerScore = 0;
	public int enemyScore = 0;


	public Toy(int aDivValue, float aRange) {
		divValue = aDivValue;
		range = aRange;
	}
	// Use this for initialization
	void Start () {
		//creates random arc with for Enemies Toys
		float rw = Random.value * divValue;
		randomWidth = Random.Range(rw - range, rw + range);
	}

	// Update is called once per frame
	void Update () {
		if(this.tag.Equals("enemyToy")) {
			float deltaX = -speed * Time.deltaTime;
			projPos.x += deltaX;
			//change y like a parabola, y=x^2/divVale + height
			projPos.y = -((((projPos.x-deltaX) * (projPos.x-deltaX))/randomWidth))+4;
			projPos.z = 0;
			if (this != null) {
				this.transform.position = projPos;
			}
		}

	}

	void OnCollisionEnter(Collision col){
		//		Debug.Log ("parent tag" + col.transform.parent.gameObject.tag);
		//		Debug.Log ("this tag " + this.transform.gameObject.tag);
		Object parent  = col.transform.parent;

		//string ct = col.transform.parent.gameObject.tag;
		//string tt = this.transform.gameObject.tag;


		//Destroys any object that collides with ground
		if (col.gameObject.name.Equals ("Ground")) {
			Destroy (this.gameObject);
		} else {

			if (this.transform.gameObject.tag.Equals ("enemyToy") && col.transform.gameObject.tag.Equals ("playerToy")) {
				//this.GetComponent<Rigidbody>().isKinematic = false;
				Destroy (col.gameObject);
				Destroy (this.gameObject);
			}
			if (parent != null) {
				//Updates players score when player hits an enemy block
				if (this.transform.gameObject.tag.Equals ("playerToy") && col.transform.parent.gameObject.tag.Equals ("enemyBlock")) {
					//if (!(this.tag.Equals ("enemyToy")) &&!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals("Ground") && !col.gameObject.name.Equals("SlingShot")) {
					GameObject camera = GameObject.Find ("Main Camera");
					MissionDemolition md = camera.GetComponent<MissionDemolition> ();
					md.UpdateScore("player", changeInScore);
					Destroy (col.gameObject);
					Destroy (this.gameObject);
				}
				//Updates enemy score when player hits an player block
				if (this.transform.gameObject.tag.Equals ("enemyToy") && col.transform.parent.gameObject.tag.Equals ("playerBlock")) {
					//if (!(this.tag.Equals ("playerToy")) &&!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals("Ground") && !col.gameObject.name.Equals("SlingShot")) {
					GameObject camera = GameObject.Find ("Main Camera");
					MissionDemolition md = camera.GetComponent<MissionDemolition> ();
					md.UpdateScore("enemy", changeInScore);
					Destroy (col.gameObject);
					Destroy (this.gameObject);
				}
				//Destroys the objects that collided
				//				if (!col.gameObject.name.Equals ("Enemy") && !col.gameObject.name.Equals ("Toy(Clone)") && !col.gameObject.name.Equals ("Ground") && !col.gameObject.name.Equals ("SlingShot")) {
				//					Destroy (col.gameObject);
				//					Destroy (this.gameObject);
				//
				//				}
			}
		}


	}


}
