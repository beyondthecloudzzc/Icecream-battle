using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolcontrol : MonoBehaviour
{
    private int curcnt = 0;
    public GameObject qpic1;
    public GameObject qpic2;
    public GameObject epic1;
    public GameObject epic2;
    public GameObject box;
    public GameObject firerockets;
    public List<int> items = null;
    public int maxItem = 2;
    public Text txtshow;
    public Text tooltime;
    float timer = 0f;
    bool usingflag = false;
    float x ;
    float y ;
    private BoxCollider2D boxCollider2D;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        curcnt = 0;
        items.Add(0);
        items.Add(0);
        boxCollider2D = this.GetComponent<BoxCollider2D>();
        music.Stop();
        //shotobj = Instantiate(firerockets, transform.position, Quaternion.identity) as GameObject;
        //shotobj.SetActive(false);
        //shotobj = Instantiate(firerockets, transform) as GameObject;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.J) && items[0] != 0&& !usingflag)
        {
            if(items[0] == 1){
                qpic1.SetActive(false);
            }
            else
            {
                qpic2.SetActive(false);
            }
            items[0] = 0;
            curcnt--;
        }
        if (Input.GetKey(KeyCode.L) && items[1] != 0 && !usingflag)
        {
            if (items[1] == 1)
            {
                epic1.SetActive(false);
            }
            else
            {
                epic2.SetActive(false);
            }
            items[1] = 0;
            curcnt--;
        }
        print("curcnt:" + curcnt.ToString());
        if ((Input.GetKey(KeyCode.Q)&& items[0]!=0)||(usingflag&& items[0] != 0))
        {
            print("进来了");
            if (items[0] == 1)
            {
                usingflag = true;
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 44f);
                boxCollider2D.size = new Vector2(50f, 44f);
                tooltime.text = (10f - timer).ToString();
                timer += Time.deltaTime;
                txtshow.text = "USING TOOL...";
                txtshow.color = Color.yellow;
                if (timer > 10f)
                {
                    items[0] = 0;
                    qpic1.SetActive(false);
                    curcnt--;
                    usingflag = false;
                    timer = 0f;
                    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 44f);
                    boxCollider2D.size = new Vector2(100f, 44f);
                }
            }
            else if(items[0] == 2)
            {
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                if (!usingflag)
                {
                    print("开始");
                    coll.enabled = false;
                    usingflag = true;
                    //Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), hurtobj.GetComponent<EdgeCollider2D>(), true);
                }
                tooltime.text = (3f - timer).ToString();
                timer += Time.deltaTime;
                txtshow.text = "USING TOOL...";
                txtshow.color = Color.yellow;
                if (timer > 3f)
                {
                    print("使用完");
                    items[0] = 0;
                    qpic2.SetActive(false);
                    curcnt--;
                    usingflag = false;
                    coll.enabled = true;
                    timer = 0f;
                   
                }
            }
        }else if((Input.GetKey(KeyCode.E) && items[1] != 0) || (usingflag && items[1] != 0))
        {
            print("in e");
            if (items[1] == 1)
            {
                usingflag = true;
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 44f);
                boxCollider2D.size = new Vector2(50f, 44f);
                tooltime.text = (10f - timer).ToString();
                timer += Time.deltaTime;
                txtshow.text = "USING TOOL...";
                txtshow.color = Color.yellow;
                if (timer > 10f)
                {
                    items[1] = 0;
                    epic1.SetActive(false);
                    curcnt--;
                    usingflag = false;
                    timer = 0f;
                    gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 44f);
                    boxCollider2D.size = new Vector2(100f, 44f);
                }
            }
            else
            {
                BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
                if (!usingflag)
                {
                    print("开始");
                    coll.enabled = false;
                    usingflag = true;
                    //Physics.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), hurtobj.GetComponent<EdgeCollider2D>(), true);
                }
                tooltime.text = (3f - timer).ToString();
                timer += Time.deltaTime;
                txtshow.text = "USING TOOL...";
                txtshow.color = Color.yellow;
                if (timer > 3f)
                {
                    print("使用完");
                    epic2.SetActive(false);
                    items[1] = 0;
                    curcnt--;
                    usingflag = false;
                    coll.enabled = true;
                    timer = 0f;
                }
            }
        }
        else 
        {
             tooltime.text = "NULL";
            
        }
        if (curcnt >= 2&&!usingflag)
        {
            txtshow.text = "FULL,USE SOME TOOLS!";
            txtshow.color = Color.red;
        }
        else if(!usingflag)
        {
            txtshow.text = "EMPTY,GET SOME TOOLS!";
            txtshow.color = Color.blue;
        }

    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "tool1"&&!usingflag)
        {
            if(items[0] == 0)
            {
                music.Play();
                items[0] = 1;
                qpic1.SetActive(true);
                curcnt++;
            }
            else if(items[1] == 0)
            {
                music.Play();
                items[1] = 1;
                epic1.SetActive(true);
                curcnt++;
            }
            else
            {
                print("道具栏满了");
                txtshow.text = "FULL,USE SOME TOOLS!";
                txtshow.color = Color.red;
            }
           
        }
        else if (collision.collider.tag == "tool2" && !usingflag)
        {
            if (items[0] == 0)
            {
                music.Play();
                items[0] = 2;
                qpic2.SetActive(true);
                curcnt++;
            }
            else if (items[1] == 0)
            {
                music.Play();
                items[1] = 2;
                epic2.SetActive(true);
                curcnt++;
            }
            else
            {
                print("道具栏满了");
                txtshow.text = "FULL,USE SOME TOOLS!";
                txtshow.color = Color.red;
            }
        }
        Destroy(collision.collider.gameObject);
        print(curcnt);
    }
   
}
