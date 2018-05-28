﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Lizard : MonoBehaviour 
{
	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D(Collider2D target)
	{
		GameObject obj = target.gameObject;
		if (!obj.GetComponent<Defender> ()) 
		{
			return;
		}
		anim.SetBool ("isAttacking", true);
		attacker.Attack (obj);
	}
}