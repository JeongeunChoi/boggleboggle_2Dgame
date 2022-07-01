using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverDirector : MonoBehaviour
{
    public Text endRound;
    GameObject gameDirector;

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.Find("GameDirector");
        endRound.text = GameDirector.endRound.ToString() +"round";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
