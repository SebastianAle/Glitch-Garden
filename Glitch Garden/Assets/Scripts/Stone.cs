using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour 
{
	private Attacker attacker;
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		attacker = GameObject.FindObjectOfType<Attacker> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.GetComponent<Attacker>()) 
		{
			anim.SetBool("isUnderAttack", true);
		}
	}

	void OnTriggerExit2D(Collider2D target)
	{
		if (target.gameObject.GetComponent<Attacker>()) 
		{
			anim.SetBool("isUnderAttack", false);
		}
	}
}
