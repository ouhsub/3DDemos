using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    // 利用公开变量引用物体和组件
    public GameObject other;
    public Transform otherTransform;
    public MeshFilter otherMesh;
    public Rigidbody otherRigid;

    public GameObject prefab;

    // SphereCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        /**
         * 查找组件和物体
         * */
        // 获取组件之后，将其引用保存到collider字段中，方便下次使用
        // collider = gameObject.GetComponent<SphereCollider>();
        // collider = this.GetComponent<SphereCollider>();
        // collider = GetComponent<SphereCollider>();
        // collider = transform.GetComponent<SphereCollider>();
        // collider = transform.GetComponent<MeshRenderer>().GetComponent<SphereCollider>();
        // collider = GetComponent<SphereCollider>().GetComponent<SphereCollider>();

        // 获取多有脚本组件
        // TestParent[] testes = GetComponents<TestParent>();
        // Debug.Log(testes.Length);


        // 通过名称获取物体
        GameObject objMainCamera = GameObject.Find("Main Camera");
        GameObject objMainLight = GameObject.Find("Directional Light");

        // 通过标签查找物体
        // 查找第一个标签为Player的物体
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // 查找所有标签为Monster的物体
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        // 修改物体标签
        player.tag = "Cube";
        // 判断标签是否是Cube
        // player.tag == "Cube"
        if (player.CompareTag("Cube"))
        {
            
        }

        // 通过父子路径获取物体
        Transform rightLeg = transform.Find("Character1_reference/Character1_Hips/Character1_RightLeg");
        Transform root = rightLeg.Find("../../../");
        Transform leftLeg = rightLeg.Find("../Character1_LeftUpLeg");

        Transform p1 = transform.parent;
        Transform p2 = transform.Find("..");

        Transform hips = transform.Find("Character1_reference/Character1_Hips");
        Transform rightLeg2 = hips.GetChild(1);

        // 遍历子物体
        for (int i=0; i<transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Debug.Log(child.name);
            Debug.Log(child.transform.childCount);
        }

        // 从父子物体中获取组件的便捷方法
        SphereCollider collider = GetComponentInChildren<SphereCollider>();
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        Rigidbody rb = GetComponentInParent<Rigidbody>();
        Light[] lights = GetComponentsInParent<Light>();

        // 分布查找隐藏的UI界面
        GameObject canvas = GameObject.Find("Canvas");
        Transform itemPanel = canvas.transform.Find("ItemPanel");



        /**
         * 用脚本创建物体，组件
         * */
         // 在场景根节点创建物体
        GameObject objA = Instantiate(prefab, null);
        // 创建一个物体，作为当前脚本所在物体的子物体
        GameObject objB = Instantiate(prefab, transform);
        // 创建一个物体，指定他的位置和朝向
        GameObject objC = Instantiate(prefab, new Vector3(3, 0, 3), Quaternion.identity);

        // 创建10个物体围成环形
        for (int i=0; i<10; i++)
        {
            Vector3 pos = new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / 10), 0, Mathf.Sin(i * (2 * Mathf.PI) / 10));
            pos *= 5;  // 圆环半径
            Instantiate(prefab, pos, Quaternion.identity);
        }


        // 用脚本创建组件
        GameObject go = GameObject.Find("Cube");
        go.AddComponent<Rigidbody>();
        // 销毁物体
        Destroy(go);
        // 立即销毁物体
        DestroyImmediate(go);

        // 定时创建和销毁物体
        Invoke("CreatePrefab", 0.5f);

        /**
         * 使用协程创建物体
         * */
        StartCoroutine(CreateObject());
    }

    int counter = 0;
    void CreatePrefab()
    {
        Vector3 pos = new Vector3(Mathf.Cos(counter * (2 * Mathf.PI) / 10), 0, Mathf.Sin(counter * (2 * Mathf.PI) / 10));
        pos *= 5;
        Instantiate(prefab, pos, Quaternion.identity);
        counter++;
        if (counter < 10)
        {
            Invoke("CreatePrefab", 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 延迟销毁物体
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject cube = GameObject.Find("Cube(Clone)");
            Destroy(cube, 0.8f);
            cube.AddComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        // 间隔0.02秒
        Debug.Log(Time.time);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
    }

    IEnumerator CreateObject()
    {
        for (int i=0; i<10; i++)
        {
            Vector3 pos = new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / 10), 0, Mathf.Sin(i * (2 * Mathf.PI) / 10));
            pos *= 5;
            Instantiate(prefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
