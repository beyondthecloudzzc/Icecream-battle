using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gethpmp : MonoBehaviour
{
    public float hp ;
    private float hpHolder=100;
    public Slider hpslider;
    public Text hprate;

    public float mp;
    private float mpHolder = 100;
    public Slider mpslider;
    public Text mprate;

    // Start is called before the first frame update
    void Start()
    {
        hp = mpslider.value*100;
        mp = hpslider.value*100;
        hpHolder = 100f;
        mpHolder = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //print("hp&mp:"+ hp.ToString ()+" "+ mp.ToString());
        hp = mpslider.value * 100;
        mp = hpslider.value * 100;
        string str = "";
        string ratestr = (System.Math.Round(hp / hpHolder * 100, 2)).ToString();
        str = ratestr + "%";
        hprate.text = str;

        str = "";
        ratestr = (System.Math.Round(mp / mpHolder * 100, 2)).ToString();
        str = ratestr + "%";
        mprate.text = str;
    }

  

}
