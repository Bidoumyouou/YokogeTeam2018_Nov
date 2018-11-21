using UnityEngine;
using System.Collections;

public class Boss_Default : E_ModeBase
{
    public int p = ~0;
    new GameObject player;
    Boss _enemy;
    public override void Mode_Start(Charactor _obj)
    {
        _enemy = _obj.GetComponent<Boss>();
        _enemy.Couter_Time = 0;

        player = GameObject.Find("TestPlayer");
        base.Mode_Start(_obj);

    }

    public override void Mode_Update(Charactor _obj)
    {
            if (player.transform.position.x > _obj.transform.position.x)
            {

                _obj.transform.localScale = new Vector2(_obj.BaseScale_x, _obj.transform.localScale.y);

            }
            else
            {
                _obj.transform.localScale = new Vector2(-_obj.BaseScale_x, _obj.transform.localScale.y);
                //_obj.transform.localScale = new Vector2(-_obj.transform.localScale.x, _obj.transform.localScale.y);
            }
 

        base.Mode_Update(_obj);

        _enemy.InRangeIlluminate();

        _enemy.Attack2_Time += Time.deltaTime;

        if(_enemy.Attack2_Time > _enemy.Attack2_Limit)
        {
            _obj.ChangeMode(4);
            _enemy.Attack2_Time = 0;

        }


    }

    public override void MakeHitBox(Charactor _obj)
    {

    }

}
