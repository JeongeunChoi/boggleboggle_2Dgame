using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    float span = 0.3f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // span만큼의 시간 이후 사라지도록 설정
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            Destroy(gameObject);
        }
    }
}
