using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Createenemy : MonoBehaviour
{
    public GameObject[] enemy;
    private int objectCount;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", speed, Random.Range(1f, 3f));
        objectCount = enemy.Length;
    }

    // Update is called once per frame
    void Create()
    {
        float y = 413f;
        float x = Random.Range(-225f, 225f);
        int pos = Random.Range(0, objectCount);
        GameObject iceobj = Instantiate(enemy[pos], transform) as GameObject;
        iceobj.transform.localPosition = new Vector3(x, y, 0);
        Destroy(iceobj, 20);
    }
}
