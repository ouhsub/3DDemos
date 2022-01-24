using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("组件执行开始函数");
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
        // Debug.Log("当前游戏进行的时间: " + Time.time);
        // transform.Translate(0, 0, 5*Time.deltaTime); // local
        // transform.position += new Vector3(0, 0, 5*Time.deltaTime); // global
        // float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        // Debug.Log("当前输入纵向：" + v + "    横向:" + h);
        transform.Translate(h * speed * Time.deltaTime, 0, 0.5f * speed * Time.deltaTime);
        if (transform.position.x < -4 || transform.position.x > 4)
        {
            transform.Translate(0, -10 * Time.deltaTime, 0);
        }

        if (transform.position.y < -20)
        {
            Time.timeScale = 0;
        }

        // 调整摄像头倾斜角度
        Transform c = Camera.main.transform;
        Quaternion cur = c.rotation;
        Quaternion target = cur * Quaternion.Euler(0, 0, h * 0.5f);
        Camera.main.transform.rotation = Quaternion.Slerp(cur, target, 0.5f);
    }
}
