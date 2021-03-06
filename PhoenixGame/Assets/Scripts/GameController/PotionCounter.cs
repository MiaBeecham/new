﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PotionCounter : MonoBehaviour {
	public Text potionCounter;
	public int potionCount=0;
	public PlayerHealth playerHealthScript;
	public GameObject playerObject;
	public PlayerStamina playerStaminaScript;
	public Animator anim;
	// Use this for initialization
	void Start () {
		potionCounter = GetComponent<Text> ();
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		playerHealthScript = playerObject.GetComponent<PlayerHealth>();
		potionCounter.text = "" + potionCount;
		playerStaminaScript = playerObject.GetComponent<PlayerStamina> ();
		anim = playerObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		detectUsePotion ();
	}

	//called by potionUsed in PlayerHealth script
	public void potionDrink(){
		//first if statement protects against accidental use of potion at max hp
		if (playerHealthScript.currentHealth != 200){
			if ((potionCount - 1) >= 0)
			{
				potionCount -= 1;
				anim.SetTrigger("isDrinking");
			}
		}
		updateCount ();
	}

	//also called by TreasureChest script
	public void updateCount(){
		potionCounter.text = "" + potionCount;
	}

	//accepts an integer and adds that number to the potion count
	public void increasePotions(int quantity){
		potionCount += quantity;
		updateCount ();
	}

	public void detectUsePotion(){
		if (Input.GetKeyDown("c"))
		{
			if (potionCount > 0)
			{
				potionDrink();
				playerHealthScript.potionUsed ();
				playerStaminaScript.potionUsed();
			}
		}
	}
}