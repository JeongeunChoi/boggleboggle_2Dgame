using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject monsterPrefab;
    float delta = 0;
    float currentRound;
    GameObject gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void Update()
    {
        currentRound = gameDirector.GetComponent<GameDirector>().roundCnt;
        this.delta += Time.deltaTime;
        if(this.delta > 1.5/currentRound) // 라운드가 증가할수록 몬스터 생성 주기가 빨라짐.
        {
            this.delta = 0;
            GameObject go = Instantiate(monsterPrefab);
            float py = Random.Range(-3.3f, 3.1f);
            float size;
            if (currentRound == 1)
            {
                size = Random.Range(1, currentRound);
            }
            else
            {
                size = Random.Range(1, currentRound * 0.6f);
            }
            
            go.transform.position = new Vector3(12, py, 0);
            go.transform.localScale = new Vector3(size, size, 1);
        }
    }
}
