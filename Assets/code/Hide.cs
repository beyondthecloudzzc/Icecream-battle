using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btn1;
    public GameObject btn2;
    public AudioSource music;
    public void stopmusic()
    {
        //停止播放音乐
        music.Stop();
        btn1.SetActive(false);
        btn2.SetActive(true);

    }
    public void startmusic()
    {
        btn2.SetActive(false);
        btn1.SetActive(true);
        music.Play();
        //开始播放音乐
    }

    
}
