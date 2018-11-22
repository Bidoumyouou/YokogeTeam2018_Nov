using UnityEngine;
using System.Collections;

public class Boss_Attack2_MagicCircle : MonoBehaviour
{
    AudioPlayer audio;

    public GameObject DarkArm;
    bool isAttack = false;
    float timer = 0;
    // Use this for initialization
    void Start()
    {
        audio = GameObject.Find("AudioList").GetComponent<AudioPlayer>();
        audio.Play(3);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1.0)
        {
            if(DarkArm != null && isAttack == false)
            {
                GameObject obj =  Instantiate(DarkArm);
                isAttack = true;
                obj.transform.position = transform.position;
                GameObject player = GameObject.Find("TestPlayer");
                //プレイヤーの向きで向きを変える
                if (player.transform.position.x > transform.position.x)
                {


                }
                else
                {
                    obj.transform.Rotate(0, 0, 180);
                    //_obj.transform.localScale = new Vector2(-_obj.transform.localScale.x, _obj.transform.localScale.y);
                }

            }
        }
        if(timer > 2.0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
