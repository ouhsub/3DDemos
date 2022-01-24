using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("���ִ�п�ʼ����");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            return;
        }
        // Debug.Log("��ǰ��Ϸ���е�ʱ��: " + Time.time);
        // transform.Translate(0, 0, 5*Time.deltaTime); // local
        // transform.position += new Vector3(0, 0, 5*Time.deltaTime); // global
        // float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        // Debug.Log("��ǰ��������" + v + "    ����:" + h);
        transform.Translate(h * speed * Time.deltaTime, 0, 0.5f * speed * Time.deltaTime);
        if (transform.position.x < -4 || transform.position.x > 4)
        {
            transform.Translate(0, -10 * Time.deltaTime, 0);
        }

        if (transform.position.y < -20)
        {
            Time.timeScale = 0;
        }

        // ��������ͷ��б�Ƕ�
        Transform c = Camera.main.transform;
        Quaternion cur = c.rotation;
        Quaternion target = cur * Quaternion.Euler(0, 0, h * 0.5f);
        Camera.main.transform.rotation = Quaternion.Slerp(cur, target, 0.5f);
    }
}
