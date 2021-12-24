using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bugremaining : MonoBehaviour
{
    TMPro.TextMeshProUGUI remainingText;
    gamesession GameSession;


    // Start is called before the first frame update
    void Start()
    {
        remainingText = GetComponent<TMPro.TextMeshProUGUI>();
        GameSession = FindObjectOfType<gamesession>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingText.text = GameSession.Getbug().ToString();
    }
}