using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    public GameObject bubblePrefab;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어 몸이 오른쪽 방향을 향할 때 버블 쏘기 가능
        if (Input.GetKeyUp(KeyCode.Space) && player.transform.localScale.x > 0)
        {
            // player가 보유한 bubble의 개수가 남아 있어야 생성 가능
            if(player.GetComponent<PlayerController>().bubbleCnt > 0)
            {
                GameObject newBubble = Instantiate(bubblePrefab);
                newBubble.transform.position = player.transform.position;
                player.GetComponent<PlayerController>().DecreaseBubbleCnt();
            }
        }
    }
}
