using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    public Image player1;
    public Image player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectPlayer(int i)
    {
        Color nowColor;
        ColorUtility.TryParseHtmlString("#D5E560", out nowColor);
        if (i == 1)
        {
            player1.color = nowColor;
        } else if(i == 2)
        {

            
            player2.color = nowColor;
        }
    }

    public void Reset()
    {
        Color nowColor;
        ColorUtility.TryParseHtmlString("#FFFFFF", out nowColor);
       
            player1.color = nowColor;
        
        
            player2.color = nowColor;
        
    }
}
