using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject ball;
    private float maxWidth;
    private float time = 2;
    private GameObject newball;
    // Use this for initialization
    void Start()
    {
        //将屏幕的宽度转换成世界坐标
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);
        //获取保龄球自身的宽度
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        //计算保龄球实例化位置的宽度
        maxWidth = moveWidth.x - ballWidth;
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            //产生一个随机数，代表实例化下一个保龄球所需的时间
            time = Random.Range(1.5f, 2.0f);
            //在保龄球实例化位置的宽度内产生一个随机数，来控制实例化的保龄球的位置
            float posX = Random.Range(-255, 255);
            Vector3 spawnPosition = new Vector3(posX, -160, 0);
            //实例化保龄球，10秒后销毁
            newball = (GameObject)Instantiate(ball, spawnPosition, Quaternion.identity);
            //如果不写时间的话，组件会被马上销毁的
            Destroy(newball, 10);
        }
    }
}
