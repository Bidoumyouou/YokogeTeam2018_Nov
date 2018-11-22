using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarmArm : MonoBehaviour {

    AudioPlayer audio;
    public GameObject Arm;
    public float expandspeed = 0.02f;
    public float speed = 0.02f;
	// Use this for initialization
	void Start () {
        audio = GameObject.Find("AudioList").GetComponent<AudioPlayer>();
        audio.Play(8);

        //Arm = GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update () {
        if (Arm.transform.localScale.x < 1)
        {
            Arm.transform.localScale = new Vector3(Arm.transform.localScale.x + expandspeed, Arm.transform.localScale.y, Arm.transform.localScale.z);
        }
        if(transform.rotation.z == 0)
        {
            transform.Translate(transform.right * speed);

        }
        else
        {
            transform.Translate(transform.right * speed* -1);

        }

    }
}
