using UnityEngine;
using System.Collections;

public class Boss_Attack1 : E_ModeBase
{
    public int p = 0;
    public Vector3 attack_offset;
    new GameObject player;
    Boss _enemy;
    public override void Mode_Start(Charactor _obj)
    {
        _enemy = _obj.GetComponent<Boss>();


        player = GameObject.Find("TestPlayer");
        base.Mode_Start(_obj);

        //前方に突っ込む
        Rigidbody2D rb = _obj.GetComponent<Rigidbody2D>();

        if (_enemy.player.transform.position.x > _enemy.transform.position.x)
        {
            //→
            rb.AddForce(new Vector2(500, 0));
            _obj.transform.localScale = new Vector3(2.5f, _obj.transform.localScale.y, _obj.transform.localScale.z);
        }
        else
        {
            rb.AddForce(new Vector2(-500, 0));
            _obj.transform.localScale = new Vector3(-2.5f, _obj.transform.localScale.y, _obj.transform.localScale.z);

        }

    }

    public override void Mode_Update(Charactor _obj)
    {
 



        base.Mode_Update(_obj);

  

    }

    public override void MakeHitBox(Charactor _obj)
    {


        Vector3 v;
        //オフセットと向きを考慮したposに当たり判定を生成
        if (!_obj.IsRight) { v = new Vector3(attack_offset.x * -1, attack_offset.y, attack_offset.z); } else { v = attack_offset; }
        _obj.hitbox[0] = GameObject.Instantiate(Attack[0], _obj.transform.position + v, Quaternion.identity) as GameObject;
        _obj.hitbox[0].transform.parent = _obj.transform;


    }

}
