using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeController : MonoBehaviour
{

    Slider lifebar_1;
    Slider lifebar_2;
    int allBlood_1;
    int allBlood_2;
    

    // Start is called before the first frame update
    void Start()
    {
        lifebar_1 = transform.Find("life_1").GetComponent<Slider>();
        lifebar_2 = transform.Find("life_2").GetComponent<Slider>();
        
        lifebar_1.value = 1f;
        lifebar_2.value = 1f;

        allBlood_1 = 100;
        allBlood_2 = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void attack(Body body, int player_index)
    {
        if(player_index == 1)
        {
            switch (body)
            {
                case Body.body: lifeControl(-20, 0); break;
                case Body.head: lifeControl(-30, 0); break;
            }
        }else if(player_index == 2)
        {
            switch (body)
            {
                case Body.body: lifeControl(0,-20); break;
                case Body.head: lifeControl(0,-30); break;
            }
        }
        
        
    }
    private void lifeControl(int blood_1,  int blood_2)
    {

        
        if (blood_1 != 0)
        {
            allBlood_1 = allBlood_1 + blood_1;
            lifebar_1.value = (allBlood_1) * 1.0f / 100;
            if (lifebar_1.value <= 0)
            {
          
                PortController.status = GameStatus.over;
                PortController.winPlayer = 2;
                SceneManager.LoadScene("GameOver");
            }
            
        }
        if (blood_2 != 0)
        {
            allBlood_2 = allBlood_2 + blood_2;
            lifebar_2.value = (allBlood_2) * 1.0f / 100;
            if (lifebar_2.value <= 0)
            {
             
                PortController.status = GameStatus.over;
                PortController.winPlayer = 1;
                SceneManager.LoadScene("GameOver");
            }
        }
    }


}
