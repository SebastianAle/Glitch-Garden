using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
	public GameObject projectile;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator anim;
	private Spawner myLaneSpawner;

	void Start()
	{
		anim = GetComponent<Animator> ();


		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) 
		{
			projectileParent = new GameObject ("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update()
	{
		if (IsAttackerAheadInLane ()) 
		{
			anim.SetBool ("isAttacking", true);
		} 
		else 
		{
			anim.SetBool ("isAttacking", false);
		}
	}

	private void Fire()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	void SetMyLaneSpawner()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) 
		{
			if (spawner.transform.position.y == this.transform.position.y) 
			{
				myLaneSpawner = spawner;
				return;
			}
		}
	}

	bool IsAttackerAheadInLane()
	{
		if (myLaneSpawner.transform.childCount <= 0) 
		{
			return false;
		} 

		foreach (Transform attacker in myLaneSpawner.transform) 
		{
			if (attacker.position.x > this.transform.position.x) 
			{
				return true;
			} 
		}

		return false;
	}
}
