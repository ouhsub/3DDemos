using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ����һ��Э��
        StartCoroutine(Timer());
    }
    // Э�̺���
    IEnumerator Timer()
    {
        // ����ѭ��ִ�У��������ᵼ����ѭ��
        while(true)
        {
            Debug.Log("Э�̲���");
            // �ȴ�һ��
            yield return new WaitForSeconds(1);
            // ��ӡ��ǰ��Ϸ������ʱ��
            Debug.Log(Time.time);
            // �ٵȴ�һ��
            yield return new WaitForSeconds(1);
        }
    }
}
