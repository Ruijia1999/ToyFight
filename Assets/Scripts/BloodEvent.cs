using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEvent
{
    // Start is called before the first frame update
    public delegate void BloodRequest(int player_1, int blood_1, int player_2, int blood_2);

    public event BloodRequest BloodEvents;
    public BloodEvent()
    {
       
    }
}
