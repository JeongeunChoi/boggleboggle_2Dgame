using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    float speed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        // 화면 밖을 벗어나면 오브젝트 삭제
        if (transform.position.x > 9.5)
        {
            Destroy(gameObject);
        }
    }

    // bubble이 monster와 닿으면 bubbled로 변환
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌");
        if (collision.gameObject.name == "monsterPrefab(Clone)")
        {
            Debug.Log("충돌");
            GameObject newBubbled = GameObject.Find("BubbledGenerator");
            newBubbled.GetComponent<BubbledGenerator>().CreateBubbled(transform.position, collision.transform.localScale);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}