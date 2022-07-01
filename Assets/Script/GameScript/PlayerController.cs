using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed = 0; // player의 속도
    public int bubbleCnt; // 보유하고 있는 bubble의 개수
    public int makeBubble; // bubble을 만들기 위해 터트린 bubbled의 수
    GameObject treasure; // 최종 라운드(10라운드)에 도달하면 보여질 보물
    GameObject gameDirector; // player의 hp와 round 정보 등을 얻기 위함.

    // Start is called before the first frame update
    void Start()
    {
        bubbleCnt = 10; // 기본 버블 갯수
        makeBubble = 0; // 버블 생성을 위한 변수
        treasure = GameObject.Find("treasure"); // 보물 오브젝트 보이지 않도록 설정
        treasure.SetActive(false);
        gameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // player 상하좌우 키로 이동
        ShowTreasure(); // 최종라운드(10라운드)가 되면 보물 표시

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

    // 충돌 기능 구현
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // player가 bubbled와 충돌하면 bubbled가 터지며 bomb을 생성
        if (collision.gameObject.name == "bubbledPrefab(Clone)")
        {
            GameObject newBomb = GameObject.Find("BombGenerator");
            newBomb.GetComponent<BombGenerator>().CreateBomb(transform.position);
            Destroy(collision.gameObject);
            // 몬스터 세개의 버블을 터트리면 버블 하나 획득
            makeBubble++;
            if (makeBubble == 3)
            {
                bubbleCnt++;
                makeBubble = 0;
            }
        } 
        // player가 monster와 충돌하면 hp가 10 감소
        else if(collision.gameObject.name == "monsterPrefab(Clone)")
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }
        // player가 treasure와 충돌 시 GameCompleteScene으로 화면 전환
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
