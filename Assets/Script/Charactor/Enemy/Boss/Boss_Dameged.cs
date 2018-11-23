using UnityEngine;

//こっちを基準にダメージモードを作る
public class Boss_Dameged : E_ModeBase
{
    public int call = 0;
    public bool ChangeToPre_index = true;

    public float Counter_Limit = 2.0f;

    Boss _boss;
    public float StopTime;//やられ硬直時間
    //攻撃の出る場所
    public override void Mode_Start(Charactor _obj)
    {
         _boss = (Boss)_obj;

        base.Mode_Start(_obj);

        _boss.IsCounter = false;
        _boss.Counter_Apper_Timer = 0;
    }

    //やられ硬直時間
    public override void Mode_Update(Charactor _obj)
    {
        base.Mode_Update(_obj);

        if (_obj.modetime > EndTime)
        {
            if (ChangeToPre_index)
            {
                _obj.ChangeMode(_obj.pre_mode_index);
            }
            else
            {
                _obj.ChangeMode(3);
            }
            //直前のモードへ(Modetimeは保持しない)
        }
        if (_obj.clash.Trigger)
        {
            _obj.modetime = 0.0f;//どういつモード中に当たったら硬直時間をリセット
        }

        _boss.Couter_Time += Time.deltaTime;
        if(_boss.Couter_Time > Counter_Limit)
        {
            _boss.Couter_Time = 0;
            _boss.IsCounter = true;
            _boss.ChangeMode(0,1);
            _boss.clash.Active = false;
            _boss.Invisible = true;
        }

    }


    public override void MakeHitBox(Charactor _obj)
    {

    }
}