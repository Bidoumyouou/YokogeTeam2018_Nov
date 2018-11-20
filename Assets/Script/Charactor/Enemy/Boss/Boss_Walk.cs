using UnityEngine;
using System.Collections;

public class Boss_Walk : E_ModeBase
{
    public int o = 0;
    public bool ReturnByWall = true;

    public float dash_speed;

    //プレイヤーを探す
    new GameObject player;


    public override void Mode_Start(Charactor _obj)
    {
        TestEnemy _enemy = _obj.GetComponent<TestEnemy>();


        player = GameObject.Find("TestPlayer");
        //Vector3 v;

        //プレイヤーの向きに応じて向きを変える
        //プレイヤーのほうが右にいるなら
        if (player.transform.position.x > _obj.transform.position.x)
        {

            _obj.transform.localScale = new Vector2(_obj.BaseScale_x, _obj.transform.localScale.y);

        }
        else
        {
            _obj.transform.localScale = new Vector2(-_obj.BaseScale_x, _obj.transform.localScale.y);
            //_obj.transform.localScale = new Vector2(-_obj.transform.localScale.x, _obj.transform.localScale.y);
        }

        base.Mode_Start(_obj);

    }

    public override void Mode_Update(Charactor _obj)
    {
        Boss _enemy = _obj.GetComponent<Boss>();

        _enemy.Move(dash_speed);
        base.Mode_Update(_obj);

        //プレイヤーの向きに応じて向きを変える
        //プレイヤーのほうが右にいるなら
        if (player.transform.position.x > _obj.transform.position.x)
        {
            _obj.transform.localScale = new Vector2(_obj.BaseScale_x, _obj.transform.localScale.y);
        }
        else
        {
            _obj.transform.localScale = new Vector2(-_obj.BaseScale_x, _obj.transform.localScale.y);

        }

        _enemy.InRangeIlluminate();
        
        /*
        //プレイヤーとの距離が一定以下なら
        if (Vector3.Distance(_obj.transform.position, player.transform.position) < AttackRange)
        {
            //_obj.ChangeMode(4);
        }
        */
        
    }

    public override void MakeHitBox(Charactor _obj)
    {

    }


}
