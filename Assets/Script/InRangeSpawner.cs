﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeSpawner : MonoBehaviour {

    bool it = false;
    public int Call_N = 1;

    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && it == false)
        {
            for (int i = 0; i < Call_N; i++)
            {
                GameObject o = Instantiate(obj);
                o.transform.position = transform.position;
            }
            it = true;
            GameObject.Destroy(this.gameObject);
            Destroy(this);

        }
    }
}