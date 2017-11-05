﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Health;
	public float Damage;
	public float Speed;
    Transform Target;
    // public static EnemySpawner Manager;
    void Start()
    {
        Target = FindObjectOfType<Base>().transform;
    }
    public void Initialize ()
	{
        transform.position = new Vector3(0, 4, -0.7f);
		Health = 25f;
		Damage = 5f;
		Speed = 0.5f;
	}
	
	 internal void OnCollisionEnter (Collision other) {
		string name = other.gameObject.name;
		// print("THIS " + name);
		if(name == "Base")
		{
			// HitBase();
			Destroy(gameObject);
		}
		if(name == "Bullet")
		{ 
			//var damage = other.gameObject.GetComponent<Bullet>().whatever;
			//Health -= damage;
            if (Health<=0)
            {
                Destroy(gameObject);
            }
		}
	}
	
	void FixedUpdate() {
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(4,0,0), step);
    }
}
