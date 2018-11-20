using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E005_Wait : E_ModeBase
{
    public override void Mode_Start(Charactor _obj)
    {

        base.Mode_Start(_obj);
    }

    public override void Mode_Update(Charactor _obj)
    {
        //CameraLockFilterがついていればプレイヤーの接近を
        //感知して動く
        EnemyNest nest = _obj.GetComponent<EnemyNest>();
        CameraLockTrigger camera;
        if (nest.CameraLockTrigger != null)
        {
            camera = nest.CameraLockTrigger.GetComponent<CameraLockTrigger>();
            if (camera.valid)
            {
                //デフォルトへ
                _obj.ChangeMode(0);
            }
        }
    }



    public override void MakeHitBox(Charactor _obj)
    {

    }
}   // Use this for initialization
