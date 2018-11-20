using UnityEngine;
using System.Collections;

public class Boss : TestEnemy
{
    public float illuminatetime;

    // Use this for initialization
    void Start()
    {
        StartEnemy();
        ChangeMode(3);

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

    }

    //AttackRangeの二倍まできたら予告する
    public void InRangeIlluminate()
    {
        E_ModeBase e_mode = (E_ModeBase)Mode;
        
        if(Vector2.Distance(transform.position, gameobject_player.transform.position) < e_mode.AttackRange * 1.5)
        {
            if(!isIllminate)
                Illuminate(illuminatetime);
        }

    }
}
