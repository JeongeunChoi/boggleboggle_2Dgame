using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject bombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBomb(Vector3 p)
    {
        GameObject newBubbled = Instantiate(bombPrefab);
        newBubbled.transform.position = p;
    }
}
