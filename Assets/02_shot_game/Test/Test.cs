using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    // ���ù�������������������
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
         * �������������
         * */
        // ��ȡ���֮�󣬽������ñ��浽collider�ֶ��У������´�ʹ��
        // collider = gameObject.GetComponent<SphereCollider>();
        // collider = this.GetComponent<SphereCollider>();
        // collider = GetComponent<SphereCollider>();
        // collider = transform.GetComponent<SphereCollider>();
        // collider = transform.GetComponent<MeshRenderer>().GetComponent<SphereCollider>();
        // collider = GetComponent<SphereCollider>().GetComponent<SphereCollider>();

        // ��ȡ���нű����
        // TestParent[] testes = GetComponents<TestParent>();
        // Debug.Log(testes.Length);


        // ͨ�����ƻ�ȡ����
        GameObject objMainCamera = GameObject.Find("Main Camera");
        GameObject objMainLight = GameObject.Find("Directional Light");

        // ͨ����ǩ��������
        // ���ҵ�һ����ǩΪPlayer������
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // �������б�ǩΪMonster������
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        // �޸������ǩ
        player.tag = "Cube";
        // �жϱ�ǩ�Ƿ���Cube
        // player.tag == "Cube"
        if (player.CompareTag("Cube"))
        {
            
        }

        // ͨ������·����ȡ����
        Transform rightLeg = transform.Find("Character1_reference/Character1_Hips/Character1_RightLeg");
        Transform root = rightLeg.Find("../../../");
        Transform leftLeg = rightLeg.Find("../Character1_LeftUpLeg");

        Transform p1 = transform.parent;
        Transform p2 = transform.Find("..");

        Transform hips = transform.Find("Character1_reference/Character1_Hips");
        Transform rightLeg2 = hips.GetChild(1);

        // ����������
        for (int i=0; i<transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Debug.Log(child.name);
            Debug.Log(child.transform.childCount);
        }

        // �Ӹ��������л�ȡ����ı�ݷ���
        SphereCollider collider = GetComponentInChildren<SphereCollider>();
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        Rigidbody rb = GetComponentInParent<Rigidbody>();
        Light[] lights = GetComponentsInParent<Light>();

        // �ֲ��������ص�UI����
        GameObject canvas = GameObject.Find("Canvas");
        Transform itemPanel = canvas.transform.Find("ItemPanel");



        /**
         * �ýű��������壬���
         * */
         // �ڳ������ڵ㴴������
        GameObject objA = Instantiate(prefab, null);
        // ����һ�����壬��Ϊ��ǰ�ű����������������
        GameObject objB = Instantiate(prefab, transform);
        // ����һ�����壬ָ������λ�úͳ���
        GameObject objC = Instantiate(prefab, new Vector3(3, 0, 3), Quaternion.identity);

        // ����10������Χ�ɻ���
        for (int i=0; i<10; i++)
        {
            Vector3 pos = new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / 10), 0, Mathf.Sin(i * (2 * Mathf.PI) / 10));
            pos *= 5;  // Բ���뾶
            Instantiate(prefab, pos, Quaternion.identity);
        }


        // �ýű��������
        GameObject go = GameObject.Find("Cube");
        go.AddComponent<Rigidbody>();
        // ��������
        Destroy(go);
        // ������������
        DestroyImmediate(go);

        // ��ʱ��������������
        Invoke("CreatePrefab", 0.5f);

        /**
         * ʹ��Э�̴�������
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
        // �ӳ���������
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
        // ���0.02��
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
