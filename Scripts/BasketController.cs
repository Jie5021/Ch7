using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasketController : MonoBehaviour
{
    public AudioClip applese;
    public AudioClip bombse;
    AudioSource aud;
    GameObject director;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; // 將遊戲設定在60fps
        this.aud = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector"); //變數director存GameDirector這個物件
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            this.aud.PlayOneShot(this.applese);
            //呼叫GameDirector腳本內的GetApple()函式來加分
            this.director.GetComponent<GameDirector>().GetApple();
        }
        else
        {
            this.aud.PlayOneShot(this.bombse);
            //呼叫GameDirector腳本內的GetBomb()函式來扣分
            this.director.GetComponent<GameDirector>().GetBomb();
        }
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 偵測滑鼠是否被按下
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 將滑鼠游標位置轉換成主視角射向3D場景的射線
            RaycastHit hit; // 宣告一個碰撞結構變數，用來接收射線撞擊到物件時回傳的資訊

            // 發射物理射線檢測：
            // ray:要發射的射線
            // out hit:將碰撞到的物體資訊寫入hit變數
            // Mathf.Infinity:射線的最大距離為無限遠
            // 若射線有碰撞到任何帶有Collider的物體，條件即成立（回傳true）
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // 
            {
                float x = Mathf.RoundToInt(hit.point.x); // 取得射線擊中物體表面處的世界座標（hit.point），對X軸四捨五入取整數（網格吸附效果）
                float z = Mathf.RoundToInt(hit.point.z); // 取得射線擊中物體表面處的世界座標（hit.point），對z軸四捨五入取整數（網格吸附效果）
                transform.position = new Vector3(x, 0, z); // 將basket移動到新的位置
            }
        }
    }
}
