using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public TestPlayer player;

    public int mode = 0;//0ならHP　1ならMP
    Slider sl;

    // Use this for initialization
    void Start()
    {
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
           
            sl.value = ((float)player.status.HP / 100.0f);
        }
        if (mode == 1)
        {
            sl.value = (float)player.status.MP / 100.0f;
        }
    }
}
