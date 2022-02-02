using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events; 
using UnityEngine;

public enum Body
{
    head,
    arm,
    body,
}


public class GameController : MonoBehaviour
{
    public LifeController lifeController;
    public PortController portController;
    public CharacterController player_1;
    public CharacterController player_2;
    public MusicController musicController;


    private void OnEnable()
    {
        portController.BloodEvents += lifeController.attack;
        portController.BloodEvents += this.Attack;

    }
    // Start is called before the first frame update
    void Start()
    {
        
   
        StartCoroutine(ReadyFightAudioPlayFinished());
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Attack(Body body, int player_index)
    {
        musicController.PlayMusic("hit");
        if (player_index == 1)
        {
            player_1.Hit(body);
        } else if(player_index == 2)
        {
            player_2.Hit(body);
        }
    }

    IEnumerator ReadyFightAudioPlayFinished()
    {
        musicController.PlayMusic("readyFight");
        yield return musicController.WaitForMusicFinished("readyFight");
        //musicController.PlayMusic("bgm");
        PortController.status = GameStatus.fighting;
    }


}
