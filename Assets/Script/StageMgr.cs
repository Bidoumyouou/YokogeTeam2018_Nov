using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour {
    public string Scenename;//シーンの名前を取得する
    [Tooltip("落下したらアウトになるライン")]public float OutLine_Y;
    //GameObject Respawn_obj;
    public RespawnPoint respawnPoint;

    void Start()
    {
        if (respawnPoint == null)
        {
            respawnPoint = GameObject.Find("RespawnPoint").GetComponent<RespawnPoint>();
        }
    }
	
	
	// Update is called once per frame
	void Update() {
        if (GameMgr.player != null)
        {


            if (GameMgr.player.transform.position.y < OutLine_Y)
            {
                GameMgr.player.Fall(10);
                //リスポーンポイントへの移動
                GameMgr.player.transform.position = respawnPoint.transform.position;
            }
        }
	}
}
