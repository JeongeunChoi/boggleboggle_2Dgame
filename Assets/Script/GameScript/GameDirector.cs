using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public Slider hpBar;
    public Text remainBubble, makeBubble, timer, roundChange, round;
    GameObject player;
    float time, showRoundTime;
    public int roundCnt;
    public static int endRound = 1;


    // Start is called before the first frame update
    void Start()
    {
        hpBar.maxValue = 100;
        hpBar.minValue = 0;
        hpBar.value = hpBar.maxValue;
        player = GameObject.Find("player");
        remainBubble.text = "remain bubble: " + player.GetComponent<PlayerController>().bubbleCnt.ToString();
        makeBubble.text = "making bubble: " + player.GetComponent<PlayerController>().makeBubble.ToString() + "/3";
        roundCnt = 1;
        roundChange.text = roundCnt + "Round";
        round.text = roundCnt.ToString() + "round";
    }

    // Update is called once per frame
    void Update()
    {
        if(hpBar.value <= hpBar.minValue)
        {
            hpBar.transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else
        {
            hpBar.transform.Find("Fill Area").gameObject.SetActive(true);
        }
        remainBubble.text = "remain bubble: " + player.GetComponent<PlayerController>().bubbleCnt.ToString();
        makeBubble.text = "making bubble: " + player.GetComponent<PlayerController>().makeBubble.ToString() + "/3";

        ShowTime();
        if(time >= 10)
        {
            RoundUp();
            showRoundTime = 0;
            round.text = roundCnt.ToString() + "round";
        }
        ShowRoundText();

        GameOver();
    }

    void ShowTime()
    {
        // 타이머 기능 구현
        time += Time.deltaTime;
        timer.text = "Timer: " + time.ToString("F1"); // 소수점 첫째자리 표시
    }

    void ShowRoundText()
    {
        // 매 라운드마다 roundText 화면에 1초간 표시
        showRoundTime += Time.deltaTime;
        if (showRoundTime > 1)
        {
            roundChange.text = "";
        }
    }

    void GameOver()
    {
        if (hpBar.value <= 0)
        {
            endRound = roundCnt;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void RoundUp()
    {
        roundCnt++;
        time = 0;
        roundChange.text = roundCnt + "Round";
    }

    public void DecreaseHp()
    {
        hpBar.value -= 10;
        if(hpBar.value <= hpBar.minValue)
        {
            hpBar.value = hpBar.minValue;
        }
    }

    public void IncreaseHp()
    {
        hpBar.value += 10;
        if(hpBar.value > hpBar.maxValue)
        {
            hpBar.value = hpBar.maxValue;
        }
    }
}
