using UnityEngine;
using System.Collections;

public class P_Run : P_ModeBase
{
    TestPlayer p;

    public float Accel = 0.02f;

    void HackRecorder(TestPlayer p)
    {
        if (CallBack_Reciver == 1)
        {
            //migiキーをスタック
            p.recorder.KeyList.Add("MyRight");
        }
        if (CallBack_Reciver == 2)
        {
            //hidariキーをスタック
            p.recorder.KeyList.Add("MyLeft");
        }

    }


    // Use this for initialization
    public override void Mode_Start(Charactor _obj)
    {
        //コールバックによってInputRecorderをハックする
        p = _obj.GetComponent<TestPlayer>();

        p.RunSpeed = 0;
 
        //アニメシグナルの呼び出し
        player.ChangeAnimeSignal(PlayerMode.P_Run);
        base.Mode_Start(_obj);
        ////////////////////////
        //以上、全アクション共通
        ////////////////////////
        NextMode[0] = 1;
        HackRecorder(p);

    }
    

    public override void Mode_Update(Charactor _obj)
    {

        //コールバックによってInputRecorderをハックする

        base.Mode_Update(_obj);

        //実際に移動する関数
        if (_obj.IsRight)
        {
            _obj.transform.localScale = new Vector3(_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
        }
        else
        {
            _obj.transform.localScale = new Vector3(-_obj.BaseScale_x, _obj.transform.localScale.y, _obj.transform.localScale.z);
        }
        _obj.transform.Translate(new Vector2(player.RunSpeed * MyCommonF.BoolToPorn(_obj.IsRight),0));


        //最新のスタック以外は排除する
        p.recorder.DeleteOldAllowStack();

        if(p.RunSpeed < p.MaxRunSpeed)
        {
            p.RunSpeed += Accel;
            if(p.RunSpeed > p.MaxRunSpeed)
            {
                p.RunSpeed = p.MaxRunSpeed;
            }
        }

    }

}

