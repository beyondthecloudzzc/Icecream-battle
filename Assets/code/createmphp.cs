using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createmphp : MonoBehaviour
{
    public GameObject[] mphp;
    private int objectCount;
    // Start is called before the first frame update
    void Start()
    {
        float interval = Random.Range(10f,30f);
        InvokeRepeating("Create",1f, interval);
        objectCount = mphp.Length;
    }

    // Update is called once per frame
    void Create()
    {
        float y = 413f;
        float x = Random.Range(-225f, 225f);
        int pos = Random.Range(0, objectCount);
        GameObject iceobj = Instantiate(mphp[pos], transform) as GameObject;
        iceobj.transform.localPosition = new Vector3(x, y, 0);
        Destroy(iceobj, 20);
    }
}
