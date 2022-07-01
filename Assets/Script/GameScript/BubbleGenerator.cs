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
        // �÷��̾� ���� ������ ������ ���� �� ���� ��� ����
        if (Input.GetKeyUp(KeyCode.Space) && player.transform.localScale.x > 0)
        {
            // player�� ������ bubble�� ������ ���� �־�� ���� ����
            if(player.GetComponent<PlayerController>().bubbleCnt > 0)
            {
                GameObject newBubble = Instantiate(bubblePrefab);
                newBubble.transform.position = player.transform.position;
                player.GetComponent<PlayerController>().DecreaseBubbleCnt();
            }
        }
    }
}
