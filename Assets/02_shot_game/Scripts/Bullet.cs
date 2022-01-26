using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 子弹飞行速度
    public float speed = 10.0f;

    // 子弹生命周期
    public float lifeTime = 2.0f;
    
    // 子弹出生时间
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        // 子弹移动
        transform.position += speed * transform.forward * Time.deltaTime;
        // 超过一定时间销毁自身
        if (startTime + lifeTime < Time.time)
        {
            Destroy(gameObject);
        }
    }
    // 当子弹碰触到其他物体时触发
    private void OnTriggerEnter(Collider other)
    {
        //
        // 
        if (CompareTag(other.tag))
        {
            return;
        }
        Destroy(gameObject);
    }
}
