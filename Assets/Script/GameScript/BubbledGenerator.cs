using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbledGenerator : MonoBehaviour
{
    public GameObject bubbledPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ȭ�� ���� ����� ���ӿ�����Ʈ ����
        if (transform.position.x < -9.5)
        {
            Destroy(gameObject);
        }
    }

    // ���� ���� �Լ�
    public void CreateBubbled(Vector3 p, Vector2 s)
    {
        GameObject newBubbled = Instantiate(bubbledPrefab);
        // ���ڷ� ���� p�� s�� ���� ��ġ�� �����ϰ� ũ�� ����
        newBubbled.transform.position = p;
        newBubbled.transform.localScale = s;
    }
}
