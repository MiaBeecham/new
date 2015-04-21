﻿using UnityEngine;
using System.Collections;

public class VictoryZone : MonoBehaviour {

	public GameObject victoryMenuObject;
	public VictoryMenu victoryMenu;

	void Start()
	{
		victoryMenuObject = GameObject.FindGameObjectWithTag ("VictoryMenu");
		victoryMenu = victoryMenuObject.GetComponent<VictoryMenu> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			victoryMenu.callVictoryMenu();
		}
	}

}