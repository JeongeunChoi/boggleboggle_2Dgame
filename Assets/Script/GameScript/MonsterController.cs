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
        // 화면 밖을 벗어나면 오브젝트 삭제
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }

    }
 
}
