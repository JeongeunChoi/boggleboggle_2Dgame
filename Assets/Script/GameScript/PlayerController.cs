using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed = 0; // player�� �ӵ�
    public int bubbleCnt; // �����ϰ� �ִ� bubble�� ����
    public int makeBubble; // bubble�� ����� ���� ��Ʈ�� bubbled�� ��
    GameObject treasure; // ���� ����(10����)�� �����ϸ� ������ ����
    GameObject gameDirector; // player�� hp�� round ���� ���� ��� ����.

    // Start is called before the first frame update
    void Start()
    {
        bubbleCnt = 10; // �⺻ ���� ����
        makeBubble = 0; // ���� ������ ���� ����
        treasure = GameObject.Find("treasure"); // ���� ������Ʈ ������ �ʵ��� ����
        treasure.SetActive(false);
        gameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // player �����¿� Ű�� �̵�
        ShowTreasure(); // ��������(10����)�� �Ǹ� ���� ǥ��

    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 9)
        {
            this.speed = 0.03f;
            this.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            transform.Translate(this.speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -9)
        {
            this.speed = -0.03f;
            this.transform.localScale = new Vector3(-1.5f, 1.5f, 0);
            transform.Translate(this.speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 3.1)
        {
            this.speed = 0.03f;
            transform.Translate(0, this.speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y>-4.5)
        {
            this.speed = -0.03f;
            transform.Translate(0, this.speed, 0);
        }
    }

    // �浹 ��� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // player�� bubbled�� �浹�ϸ� bubbled�� ������ bomb�� ����
        if (collision.gameObject.name == "bubbledPrefab(Clone)")
        {
            GameObject newBomb = GameObject.Find("BombGenerator");
            newBomb.GetComponent<BombGenerator>().CreateBomb(transform.position);
            Destroy(collision.gameObject);
            // ���� ������ ������ ��Ʈ���� ���� �ϳ� ȹ��
            makeBubble++;
            if (makeBubble == 3)
            {
                bubbleCnt++;
                makeBubble = 0;
            }
        } 
        // player�� monster�� �浹�ϸ� hp�� 10 ����
        else if(collision.gameObject.name == "monsterPrefab(Clone)")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }
        // player�� treasure�� �浹 �� GameCompleteScene���� ȭ�� ��ȯ
        else if(collision.gameObject.name == "treasure")
        {
            SceneManager.LoadScene("GameCompleteScene");
        }
    }

    void ShowTreasure()
    {
        if(gameDirector.GetComponent<GameDirector>().roundCnt == 10)
        {
            treasure.SetActive(true);
        }
    }

    public void DecreaseBubbleCnt()
    {
        bubbleCnt--;
    }
}
