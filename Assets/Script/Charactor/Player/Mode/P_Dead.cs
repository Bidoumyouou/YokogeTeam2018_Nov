using UnityEngine;
using System.Collections;

public class P_Dead : P_ModeBase
{
    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        //gameMgr = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        gameMgr = GameObject.Find("G_MGR").GetComponent<GameMgr>();


        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Dead);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;
        gameMgr.MakeGameOverUI();
    }
    public override void Mode_Update(Charactor _obj)
    {
       


        base.Mode_Update(_obj);
        if(_obj.modetime >EndTime)
        {

            //ゲームオーバー処理の呼び出し

            gameMgr.GameOver();
            _obj.ChangeMode(0);
            //復活
        }


    }

}