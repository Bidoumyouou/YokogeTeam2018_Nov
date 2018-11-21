using UnityEngine;
using System.Collections;

public class Boss_Attack2_MagicCircle : MonoBehaviour
{
    public GameObject DarkArm;

    float timer = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1.0)
        {
            if(DarkArm != null)
            {
                Instantiate(DarkArm);
            }
        }
    }
}
