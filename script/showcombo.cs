using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class showcombo : MonoBehaviour
{
    TextMeshProUGUI comboText;
    gamesession GameSession;


    // Start is called before the first frame update
    void Start()
    {
        comboText = GetComponent<TextMeshProUGUI>();
        GameSession = FindObjectOfType<gamesession>();
    }

    // Update is called once per frame
    void Update()
    {
        comboText.text = GameSession.getCombo().ToString();
    }
}
