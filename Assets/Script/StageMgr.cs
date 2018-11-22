using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMgr : MonoBehaviour {
    public AudioPlayer audioPlayer;

    public string Scenename;//シーンの名前を取得する
    [Tooltip("落下したらアウトになるライン")]public float OutLine_Y;
    //GameObject Respawn_obj;
    public RespawnPoint respawnPoint;

    public CameraControl camera;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        camera.mode = 0;//トラックモードへ
        audioPlayer = GameObject.Find("AudioList").GetComponent<AudioPlayer>();

        if (respawnPoint == null)
        {
            respawnPoint = GameObject.Find("RespawnPoint").GetComponent<RespawnPoint>();
        }

        if (Scenename == "Stage0")
        {
            audioPlayer.PlayBGM(0);

        }else if(Scenename == "Stage8")
        {
            audioPlayer.PlayBGM(2);
        }
        else
        {
            audioPlayer.PlayBGM(1);
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
