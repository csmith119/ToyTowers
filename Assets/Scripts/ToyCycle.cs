using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Coded by Christy Smith and Will Timpson
public class ToyCycle : MonoBehaviour {
	//Starts the index for the parts array at 0
	private int count = 0;

	//Displays the next body part in the array when clicked
	public void OnButtonChangePartForward(Sprite[] parts, string objectName){
		//checks to see if the count needs to cycle to the beginning
		if (count==parts.Length-1){
			count = 0; 
		}
		//if count doesn't need to cycle, it increases
		else{
			count++;
		}
		//Finds the target object and replaces it's image with the next toy part
		GameObject.Find(objectName).GetComponent<SpriteRenderer>().sprite = parts[count];
	}
	//Displays the previous body part in the array when clicked
	public void OnButtonChangePartBackward(Sprite[] parts, string objectName){
		//checks to see if the count needs to cycle to the beginning
		if (count==0){
			count = parts.Length-1;
		}
		//if count doesn't need to cycle, it decreases
		else{
			count--;
		}
		//Finds the target object and replaces it's image with the previous toy part
		GameObject.Find(objectName).GetComponent<SpriteRenderer>().sprite = parts[count];
	}
}