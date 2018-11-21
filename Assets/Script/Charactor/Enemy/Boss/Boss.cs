using UnityEngine;
using System.Collections;

public class Boss : TestEnemy
{
    public float illuminatetime;

    public GameObject DarkArm;

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

    public void Dissable()
    {
        renderer.color = Color.clear;
    }

    public void MakeDarkHand()
    {
        GameObject g = Instantiate(DarkArm);
        g.transform.position = transform.position;
        g.transform.Translate(new Vector3(Random.Range(-10f, 10f), 0, 0));
        
    }

}
