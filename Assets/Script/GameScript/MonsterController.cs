using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float speed = 0.01f;
    GameObject bubble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((-1) * speed, 0, 0);
        // ȭ�� ���� ����� ������Ʈ ����
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }

    }
 
}
