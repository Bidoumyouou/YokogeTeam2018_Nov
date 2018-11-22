using UnityEngine;
using UnityEditor;

public class CuiInObject : MonoBehaviour
{
    //フェードの仕方について
    public float ApperTime = 1.0f;//出現時間
    float time;
    private void Start()
    {
        AudioPlayer audio = GameObject.Find("AudioList").GetComponent<AudioPlayer>();
        audio.Play(5);

    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > ApperTime)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}