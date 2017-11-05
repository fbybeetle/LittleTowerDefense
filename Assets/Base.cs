﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        this.transform.position = new Vector3(4f, 0f, -0.7f);
    }

    // Use this for initialization
    internal void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            SliderManager.DeductHealth(collision.collider.GetComponent<Enemy>().Damage);
        }
    }
}
