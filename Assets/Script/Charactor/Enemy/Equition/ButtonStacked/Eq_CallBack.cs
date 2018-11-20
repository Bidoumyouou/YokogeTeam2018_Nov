using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Eq_CallBack : EqitionBase
{
    public bool BOOL;
    public int CallBack_N;

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if(_mode.CallBack_Reciver == CallBack_N)
        {
            return BOOL;
        }
        else
        {
            return !BOOL;

        }
    }

}
