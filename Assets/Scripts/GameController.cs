using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events; 
using UnityEngine;

public enum Body
{
    head,
    hand,
    arm,
    chest,
}

public class GameController : MonoBehaviour
{
    public LifeController lifeController;
    public PortController portController;
    GameObject player_1;
    GameObject player_2;


    private void OnEnable()
    {
        portController.BloodEvents += lifeController.attack;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            portController.AttackHead();
            Debug.Log("Attack");
        }
    }
}
