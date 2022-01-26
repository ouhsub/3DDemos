using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform followTarget;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // 算出从目标到摄像机的向量，作为摄像机的偏移量
        offset = transform.position - followTarget.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // 每帧更新摄像机的位置
        transform.position = followTarget.position + offset;
    }
}
