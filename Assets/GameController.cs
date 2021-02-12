using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int lives;
    public Text livesText;



    // Start is called before the first frame update
    void Start()
    {
        scoreCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void scoreCheck()
{
    livesText.text = " " + lives.ToString();
}
}
