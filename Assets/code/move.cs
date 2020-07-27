using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public float MoveSpeed;
    public float xmin, xmax, ymax, ymin;
    private Rigidbody2D rb;
    public float hp = 100f;
    private float hpHolder;
    public float mp = 100;
    private float mpHolder;
    public Slider slider;
    public Slider mpslider;
    public float runspeed;
    Vector2 worldPosLeftBottom;
    Vector2 worldPosTopRight;
    public Text _scoreText;
    public int score;
    bool isstart = true;
    private float timer = 0f;
    public float coldTime = 10f;
    public Text mprate;
    public float usetime = 0.5f;
    public float coldusetime =3f;
    bool flag = false;
    public AudioSource getmusic;
    public Text CCNum;
    //public Createicecream cream;
    void Start()
    {
        score = 0;
        //SetScore(0);
        hpHolder = hp;
        mpHolder = mp;
        runspeed = 150f;

    }
    void Update()
    {
        //float MoveX = Input.GetAxis("Horizontal");
        //float MoveY = Input.GetAxis("Vertical");
        // Vector3 v_Move = new Vector3(MoveX, 0, MoveY);
        //Vector2 pos = transform.position;
        //hpjudge();
        string str = "";
        if (Input.GetKey(KeyCode.K)&& mp > 0 && isstart)
        {
            MoveSpeed = runspeed;
            mp -= (float)0.1;
            if (mp < 0)
            {
                print("到0冷却！");
                flag = true;
                isstart = false;
                mp = 0;
                CCNum.color = Color.blue;
            }
            mpslider.value = (float)mp / mpHolder;
            timer += Time.deltaTime;
            if (timer > usetime)
            {
                print("使用冷却！");
                isstart = false;
                timer = 0f;
                CCNum.color = Color.blue;

            }
        }
        if (isstart && !flag)//增加
        {

            MoveSpeed = 80;
            if (mp < 20)
            {
                mp += (float)0.005;
            }else if (mp<50)
            {
                mp += (float)0.0005;
            }else if(mp>=50)
            {
                mp += (float)0.00005;
            }
            
            if (mp > 100)
            {
                mp = 100;
            }
            mpslider.value = (float)mp / mpHolder;
        }
        else if (!isstart && !flag)//使用冷却
        {
            timer += Time.deltaTime;
            print("冷却中！！！！！" + timer.ToString());
            CCNum.text =(System.Math.Round(coldusetime-timer,1)).ToString();
            if (timer >= coldusetime)
            {
                isstart = true;
                timer = 0f;
                CCNum.text = "OK!";
                CCNum.color = Color.red;
            }
        } else if (!isstart && flag)//到0冷却
        {
            timer += Time.deltaTime;
            print("冷却中！！！！！" + timer.ToString());
            CCNum.text = (System.Math.Round(coldTime - timer, 1)).ToString();
            if (timer >= coldTime)
            {
                isstart = true;
                flag = false;
                timer = 0f;
                CCNum.text = "OK!";
                CCNum.color = Color.red;
            }
        }
        string ratestr = (Math.Round(mp / mpHolder * 100, 2)).ToString();
        str = ratestr + "%";
        mprate.text = str;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * MoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * MoveSpeed);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, (int)(gameObject.GetComponent<RectTransform>().sizeDelta[0]/2), 551- (int)(gameObject.GetComponent<RectTransform>().sizeDelta[0] / 2)), Mathf.Clamp(transform.position.y, 22, 22), transform.position.z);
        //rigidbody.position =new Vector3(Mathf.Clamp(rigidbody.position.x, xmin, xmax),0,Mathf.Clamp(rigidbody.position.y, ymin, ymax));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "mpplus")
        {
            getmusic.Play();
            print("get mp");
            mp += 20f;
            if (mp > 100)
            {
                mp = 100;
            }
            mpslider.value = (float)mp / mpHolder;
            Destroy(collision.collider.gameObject);
        }    
}

}
