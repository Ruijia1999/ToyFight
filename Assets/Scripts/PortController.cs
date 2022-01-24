using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Threading;
using System.Text;
public class PortController : MonoBehaviour
{

    private SerialPort sp;
    private Thread receiveThread;  
    public string portName = "COM5";
    public int baudRate = 9600;
    public Parity parity = Parity.None;
    public int dataBits = 8;
    public StopBits stopBits = StopBits.One;

    public delegate void BloodRequest(Body player_1, Body player_2);

    public event BloodRequest BloodEvents;

    void Start()
    {
        //OpenPort();
        //receiveThread = new Thread(ReceiveThreadfunction);
        //receiveThread.IsBackground = true;
        //receiveThread.Start();
    }
    // Update is called once per frame
    void Update()
    {
    }

    #region 
    public void OpenPort()
    {
  
        sp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
        sp.ReadTimeout = 4;
        try
        {
            sp.Open();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    #endregion
    

    #region Handle the signals
    private void ReceiveThreadfunction()
    {
        while (true)
        {

           // Debug.Log("aa");
            if (this.sp != null && this.sp.IsOpen)
            {
                try
                {
                    String strRec = sp.ReadLine();        
                    Debug.Log(strRec);
                    if (strRec.Equals("255"))
                    {
                       // BloodEvents(-5, 0);

                    }
                }
                catch
                {
                    //continue;
                }
            }
        }
    }
    #endregion

    public void AttackHead()
    {
        BloodEvents(Body.head, Body.hand);
    }
}