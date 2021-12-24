using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoretext : MonoBehaviour
{
    TextMeshProUGUI ScoreText;
    gamesession GameSession;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        GameSession = FindObjectOfType<gamesession>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = GameSession.GetScore().ToString();
    }
}
