using UnityEngine;
using System.Collections;

public class Boss : TestEnemy
{
    public float illuminatetime;

    public GameObject NullMagicCircle;
    public GameObject DarkArm;
    public TestPlayer player;

    public GameObject CameraPrefab;
    Color tmp_color;
    // Use this for initialization
    void Start()
    {
        CameraPrefab = GameObject.Find("Main Camera");
        player = GameObject.Find("TestPlayer").GetComponent<TestPlayer>();

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
        tmp_color = renderer.color;
        renderer.color = Color.clear;
        transform.localScale = new Vector3(0, 0, 0);
    }

    public void MakeDarkHand()
    {

        GameObject g = Instantiate(DarkArm);
        //g.transform.position = player.transform.position;
        g.transform.position = new Vector3(CameraPrefab.transform.position.x, player.transform.position.y, player.transform.position.z);
        g.transform.Translate(new Vector3(Random.Range(-7f, 7f), 0, 0));

    }
    new Transform tr;

    public void MakeNullMagicCircle()
    {
        GameObject g = Instantiate(NullMagicCircle);
        g.transform.position = new Vector3(CameraPrefab.transform.position.x, player.transform.position.y, player.transform.position.z);
        g.transform.Translate(new Vector3(Random.Range(-7f, 7f), 0, 0));

        tr = g.transform;

    }


    public void Appear()
    {
        transform.position = tr.position;
        renderer.color = tmp_color;
        transform.localScale = new Vector3(2.5f, 2.5f, 1);
        ChangeMode(8);
    }
}
