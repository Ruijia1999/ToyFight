using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public PortController portController;
    public MusicController musicController;

    GameObject player1_win;
    GameObject player2_win;

    // Start is called before the first frame update
    void Start()
    {

        
        player1_win = transform.Find("player1_win").gameObject;
        player2_win =transform.Find("player2_win").gameObject;
        PlayerWin(PortController.winPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerWin(int winPlayerIndex)
    {
        musicController.PlayMusic("victory");

        if (winPlayerIndex == 1)
        {
            player1_win.SetActive(true);
            player2_win.SetActive(false);
        }
        else if (winPlayerIndex == 2)
        {
            player2_win.SetActive(true);
            player1_win.SetActive(false);
        }

    }

    public void PlayAgain()
    {
        PortController.status = GameStatus.over;
        player2_win.SetActive(false);
        player1_win.SetActive(false);
    }
}
