using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemGenerator : MonoBehaviour
{
    public GameObject ApplePrefab;
    public GameObject BombPrefab;
    float span = 1.0f;     //生成的時間間隔
    float delta = 0;       //計時器累加變數，記錄自上次生成以來經過的時間
    int ratio = 2;         //炸彈生成的機率權重
    float speed = -0.03f;  //掉落物的下落速度

    public void setParameter(float span, float speed, int ratio) //能讓其他腳本能調整遊戲參數
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; //累加每幀經過的時間
        if (this.delta > this.span) //當累加時間超過設定的生成間隔
        {
            this.delta = 0; //重置計時器
            GameObject item; //宣告生成出來的道具變數
            int dice = Random.Range(1, 11); // 隨機產生範圍為[1, 11)的數，即1~10
            if (dice <= this.ratio) //當dice小於等於ratio(預設為 2)時生成炸彈，其餘生成蘋果
            {
                item = Instantiate(BombPrefab);
            }
            else
            {
                item = Instantiate(ApplePrefab);
            }
            //隨機決定生成位置（X 與 Z 軸），範圍是-1~1
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z); //將生成的道具放在前面隨機位置產生器產生的位置，且高度固定4
            item.GetComponent<ItemController>().dropSpeed = this.speed; //將道具的下落速度傳遞給道具身上的ItemController腳本
        }
    }
}
