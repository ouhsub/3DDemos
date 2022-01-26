using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 开启一个协程
        StartCoroutine(Timer());
    }
    // 协程函数
    IEnumerator Timer()
    {
        // 不断循环执行，但并不会导致死循环
        while(true)
        {
            Debug.Log("协程测试");
            // 等待一秒
            yield return new WaitForSeconds(1);
            // 打印当前游戏经历的时间
            Debug.Log(Time.time);
            // 再等待一秒
            yield return new WaitForSeconds(1);
        }
    }
}
