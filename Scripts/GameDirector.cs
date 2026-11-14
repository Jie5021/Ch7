using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject generator;
    TextMeshProUGUI levelText; // 宣告用來存放關卡文字元件的變數
    float time = 30.0f;
    int point = 0;

    public void GetApple()
    {
        this.point += 100;
    }

    public void GetBomb()
    {
        this.point /= 2;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.levelText = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        this.generator = GameObject.Find("ItemGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        if(this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().setParameter(10000.0f, 0, 0);
        }
        else if (30 >= this.time && this.time > 20)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(1.0f, -0.03f, 2);
            this.levelText.text = (this.time > 28.5f) ? "Level 1" : "";
        }
        else if (20 >= this.time && this.time > 10)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.8f, -0.04f, 4);
            this.levelText.text = (this.time > 18.5f) ? "Level 2" : "";
        }
        else if (10 >= this.time && this.time > 5)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.5f, -0.07f, 6);
            this.levelText.text = (this.time > 8.5f) ? "Level 3" : "";
        }
        else if (5 >= this.time && this.time > 0)
        {
            this.generator.GetComponent<ItemGenerator>().setParameter(0.6f, -0.06f, 5);
            this.levelText.text = (this.time > 3.5f) ? "Level 4" : "";
        }
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " Point";
    }
}
