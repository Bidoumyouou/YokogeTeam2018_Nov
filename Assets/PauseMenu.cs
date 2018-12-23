using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PauseMenu : MonoBehaviour {

    bool NowAxis = false;
    bool PrevAxis = false;

    RectTransform yes_obj;
    RectTransform no_obj;

    public GameMgr GameMgr;

    int cursol = 1;//最初はNo
    // Use this for initialization
    void Start () {
        //yesnoの取得
        GameMgr = GameObject.Find("G_MGR").GetComponent<GameMgr>();
        yes_obj = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        no_obj = transform.GetChild(2).gameObject.GetComponent<RectTransform>();
    }

    bool CheckAxisTrigger()
    {
        if(NowAxis == true && PrevAxis == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update () {

        //右ジョイスティック
        if (Input.GetAxis("MyHorizontal") != 0)
        {
            NowAxis = true;
        }
        else
        {
            NowAxis = false;
        }

        //No
        if (cursol == 1)
        {
             
             no_obj.localScale = new Vector3(0.8f,0.8f,1);
            yes_obj.localScale = new Vector3(0.6f, 0.6f, 1);

            //カーソル移動
            if ( CheckAxisTrigger() || Input.GetButtonDown("MyLeft") || Input.GetButtonDown("MyRight"))
            {
                cursol = 0;
            }

            //ポーズの終了
            if(Input.GetButtonDown("MyZ") || Input.GetButtonDown("Cancel"))
            {
                GameMgr.IsPause = false;
                GameMgr.EndPose();
            }
        }
        //Yes
        else
        {
             no_obj.localScale = new Vector3(0.6f, 0.6f, 1);
            yes_obj.localScale = new Vector3(0.8f, 0.8f, 1);
            //カーソル移動
            if (CheckAxisTrigger() || Input.GetButtonDown("MyLeft") || Input.GetButtonDown("MyRight"))
            {
                cursol = 1;
            }


            //ポーズの終了
            if (Input.GetButtonDown("Cancel"))
            {
                GameMgr.IsPause = false;
                GameMgr.EndPose();

            }

            //ゲームの終了
            if (Input.GetButtonDown("MyZ"))
            {
                #if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
                #elif UNITY_STANDALONE

                    Application.Quit();

                #endif
            }

        }

        PrevAxis = NowAxis;
    }
}
