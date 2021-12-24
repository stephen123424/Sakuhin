using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scorestar : MonoBehaviour
{
    RawImage star;
    gamesession GameSession;
    int score;
    [SerializeField] Texture fullstar;

    // Start is called before the first frame update
    void Start()
    {
        GameSession = FindObjectOfType<gamesession>();
        star = GetComponent<RawImage>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameSession.GetScore();
        if (score>= 4000)
        {
            star.texture = fullstar;
        }
        
    }
}
