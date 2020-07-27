using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gethurt : MonoBehaviour
{
    public float hp = 100;
    private float hpHolder;
    public float mp = 100;
    public Slider slider;
    public int score;
    public Text _scoreText;
    public Text hprate;
    public GameObject ingameMenu;
    public GameObject ingameMenu2;
    public int target;
    public Text targettext;
    public AudioSource music;
    public AudioSource getmusic;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScore(0);
        hpHolder = hp;
        target = (int)Random.Range(150f, 400f);
        targettext.text = target.ToString();
        music.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        string str = "";
        string ratestr = (System.Math.Round(hp / hpHolder * 100, 2)).ToString();
        str = ratestr + "%";
        hprate.text = str;
        hpjudge();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "pick up")
        {
            
            SetScore(1);
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "pick up 2")
        {

            SetScore(4);
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "hurt")
        {
            music.Play();
            SetScore(-5);
            hp -= 3f;
            if (hp <= 0)
            {
                hp = 0;
            }
            slider.value = (float)hp / hpHolder;
            Destroy(collision.collider.gameObject);
          
        }else if(collision.collider.tag == "hurt_10")
        {
            music.Play();
            SetScore(-2);
            float hurt = Random.Range(8f, 12f);
            hp -= hurt;
            if (hp <=0)
            {
                hp = 0;
            }
            slider.value = (float)hp / hpHolder;
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "continue_hurt")
        {
            //SetScore(-5);
            music.Play();
            float hurt = Random.Range(12f, 15f);
            hp -= hurt;
            if (hp <= 0)
            {
                hp = 0;
            }
            slider.value = (float)hp / hpHolder;
            Destroy(collision.collider.gameObject);

        }else if (collision.collider.tag == "hpplus")
        {
            getmusic.Play();
            hp += 10;
            if (hp > 100)
            {
                hp = 100;
            }
            Destroy(collision.collider.gameObject);
        }
    }

    void SetScore(int _score)
    {
        score += _score;
        if (score < 0)
        {
            score = 0;
        }
        _scoreText.text = score.ToString();
        if (score >= target)
        {
            OnPause2();
        }
    }
    void hpjudge()//当受到伤害
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            print("已摧毁");
            OnPause();
        }
        else
        {
            print("游戏中");
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }

    public void OnPause2()
    {
        Time.timeScale = 0;
        ingameMenu2.SetActive(true);
    }
}
