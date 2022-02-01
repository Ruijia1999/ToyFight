using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class CharacterController : MonoBehaviour
{
    public VisualEffect head;
    public VisualEffect left_arm;
    public VisualEffect right_arm;
    public VisualEffect chest;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Hit(Body body)
    {
        switch (body)
        {
            case Body.body:
                if (chest.gameObject.activeSelf == false)
                {
                    chest.gameObject.SetActive(true);
                }

                else
                {
                    chest.Play();
                }
                break;
            case Body.head:
                if (head.gameObject.activeSelf == false)
                {
                    head.gameObject.SetActive(true);
                }
                    
                else
                {
                    head.Play();
                }
                break;
        }
    }
}
