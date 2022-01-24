using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        lifebar_1.value = 1;
        lifebar_2.value = 1;

        allBlood_1 = 100;
        allBlood_2 = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void attack(Body player_1, Body player_2)
    {
       
        if(player_1 == Body.head && player_2 == Body.hand)
        {
            lifeControl(-5, 0);
        }
    }
    private void lifeControl(int blood_1,  int blood_2)
    {
        
        if (blood_1 != 0)
        {
            allBlood_1 = allBlood_1 + blood_1;
            lifebar_1.value = (allBlood_1)*1.0f/100;
            
        }
        if(blood_2 != 0)
        {
            allBlood_2 = allBlood_2 + blood_2;
            lifebar_2.value = (allBlood_2) * 1.0f / 100;
        }
    }

}
