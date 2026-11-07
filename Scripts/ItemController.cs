using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f; // 掉落速度，負代表朝Y軸負方向，也就是向下移動
    // Update is called once per frame
    void Update()
    {
        // 物件沿著自身坐標軸的Y方向平移 dropSpeed的距離(持續下落)
        // Space.World，強制依照世界座標系的垂直向下平移(解決素材加入場景內是歪的，經rotation調整後，下落的方向改變)
        transform.Translate(0, this.dropSpeed, 0, Space.World);
        if (transform.position.y < -1.0f) // 判斷物件是否已經掉到地板
        {
            Destroy(gameObject); // 將遊戲物件從場景中刪除
        }
    }
}
