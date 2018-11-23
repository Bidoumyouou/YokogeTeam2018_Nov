using UnityEngine;
using System.Collections;

public class Boss : TestEnemy
{
    public GameObject CounterLune;
    public GameObject CounterLune_Prefab;

    public float illuminatetime;

    public GameObject NullMagicCircle;
    public GameObject DarkArm;
    public TestPlayer player;

    public GameObject CameraPrefab;
    public float Attack2_Time = 0;
    public float Couter_Time = 0;

    public float Attack2_Limit;

    Color tmp_color;

    public bool IsCounter = false;
    public float Counter_Apper_Time = 30.0f;
    public float Counter_Apper_Timer = 0;
    E_ModeBase e;

// Use this for initialization
void Start()
    {
        //生成時にカメラロックを探して自分を除去対象に入れる

        CameraLockTrigger locktrigger = GameObject.Find("CameraLockTrigger").GetComponent<CameraLockTrigger>();
        locktrigger.TargetObjectForDelete[0] = this.gameObject;
        locktrigger.DeleteForEnemyDie = true;

        Attack2_Limit = Random.Range(5,10);

        CameraPrefab = GameObject.Find("Main Camera");
        player = GameObject.Find("TestPlayer").GetComponent<TestPlayer>();

        StartEnemy();
        ChangeMode(3);

    }

    // Update is called once per frame
    void Update()
    {
        Invisible = false;
        e = (E_ModeBase)Mode;

        base.Update();

        if (Mode.index != 1)
        {
            if (IsCounter == true)
            {
                e.Strength = 3;
            }
            else
            {
                e.Strength = 2;
            }
        }
        else
        {
            e.Strength = 0;
        }

        if (IsCounter)
        {
            Counter_Apper_Timer += Time.deltaTime;
            if(Counter_Apper_Timer > Counter_Apper_Time)
            {
                IsCounter = false;
                Counter_Apper_Timer = 0;
            }
        }
        //ルーンプレハブの整備
        if(IsCounter && CounterLune == null)
        {
           CounterLune = GameObject.Instantiate(CounterLune_Prefab,transform.position,Quaternion.identity);
            CounterLune.transform.parent = transform;

        }
        if(!IsCounter && CounterLune  != null)
        {
            GameObject.Destroy(CounterLune);
        }
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
        g.transform.Translate(new Vector3(Random.Range(-7f, 7f),01, 0));

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
        transform.Translate(0, 1, 0);
        renderer.color = First_Color;
        transform.localScale = new Vector3(2.5f, 2.5f, 1);
        ChangeMode(8);
    }
}
