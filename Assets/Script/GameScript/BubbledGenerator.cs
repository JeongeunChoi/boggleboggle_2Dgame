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
        // 화면 밖을 벗어나면 게임오브젝트 삭제
        if (transform.position.x < -9.5)
        {
            Destroy(gameObject);
        }
    }

    // 버블 생성 함수
    public void CreateBubbled(Vector3 p, Vector2 s)
    {
        GameObject newBubbled = Instantiate(bubbledPrefab);
        // 인자로 받은 p와 s를 통해 위치를 생성하고 크기 설정
        newBubbled.transform.position = p;
        newBubbled.transform.localScale = s;
    }
}
