using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Createicecream : MonoBehaviour
{
    public GameObject[] icecream;
    private int objectCount;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Create", 1f, 1f);
        objectCount = icecream.Length;
    }
    void Create()
    {
        float y = 413f;
        float x = Random.Range(-225f, 225f);
        int pos = Random.Range(0, objectCount);
        GameObject iceobj = Instantiate(icecream[pos], transform) as GameObject;
        iceobj.transform.localPosition = new Vector3(x, y, 0);
        Destroy(iceobj,20);/*
        if (pos == 2)
        {
            print(pos);
        }
        else
        {
            print(pos);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   

}
