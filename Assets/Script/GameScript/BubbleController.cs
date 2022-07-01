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
        // ȭ�� ���� ����� ������Ʈ ����
        if (transform.position.x > 9.5)
        {
            Destroy(gameObject);
        }
    }

    // bubble�� monster�� ������ bubbled�� ��ȯ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹");
        if (collision.gameObject.name == "monsterPrefab(Clone)")
        {
            Debug.Log("�浹");
            GameObject newBubbled = GameObject.Find("BubbledGenerator");
            newBubbled.GetComponent<BubbledGenerator>().CreateBubbled(transform.position, collision.transform.localScale);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}