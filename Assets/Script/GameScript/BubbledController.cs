using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbledController : MonoBehaviour
{
    float speed = 0.007f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.003f, speed, 0);

        // º®¿¡ ´êÀ¸¸é Æ¨±â°Ô ÇÏ±â
        float dy = transform.position.y;
        if (dy > 3.1 || dy < -4.3) speed *= -1;
        
    }
}
