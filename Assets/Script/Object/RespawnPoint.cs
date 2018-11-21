using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {

    new StageMgr s_mgr;

    public int ID;
	// Use this for initialization
	void Start () {
        s_mgr = GameObject.Find("StageManager").GetComponent<StageMgr>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //このリスポーンポイントを落下リスポーン地点にする
            s_mgr.respawnPoint = this;
        }
    }
}
