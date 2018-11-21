using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class Eq_Probability : EqitionBase
{
    public float Percent;

    public override bool Equition(Charactor _obj, ModeBase _mode)
    {
        if(_mode.ModeChange_Random < Percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
