#define Test

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Threading;
using System.Text;
using UnityEngine.SceneManagement;


public enum GameStatus
{
    ready,
    block,
    fighting,
    over
}

public class PortController : MonoBehaviour
{

    public StartMenu startMenu;
    public static GameStatus status = GameStatus.ready;
    public static int winPlayer = 0;
    private SerialPort sp;
    private Thread receiveThread;  
    public string portName = "COM3";
    public int baudRate = 9600;
    public Parity parity = Parity.None;
    public int dataBits = 8;
    public StopBits stopBits = StopBits.One;
   

    private bool ready_1 = false;
    private bool ready_2 = false;
    public delegate void BloodRequest(Body body, int player_index);

    public event BloodRequest BloodEvents;

    private float coolTime = 1;
    private float currentTime = 0;
    private Queue<String> msgQueue = new Queue<string>();
    void Start()
    {
        OpenPort();
        
        receiveThread = new Thread(ReceiveThreadfunction);
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(status == GameStatus.ready)
        {
            if (ready_1 && ready_2)
            {
                StartGame();
                status = GameStatus.block;
                ready_1 = false;
                ready_2 = false;
            }

        }
        else if (status == GameStatus.over)
        {
            if (ready_1 && ready_2)
            {
                RestartGame();
                status = GameStatus.block;
                ready_1 = false;
                ready_2 = false;
            }
        }
        if (msgQueue.Count != 0)
        {
            while (msgQueue.Count != 0)
            {
                RecieveSignal(msgQueue.Dequeue());
            }
            
        }
        currentTime += Time.deltaTime;

#if Test
        if (Input.GetKeyDown(KeyCode.A))
        {
            msgQueue.Enqueue("head_1");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            msgQueue.Enqueue("body_1");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            msgQueue.Enqueue("head_2");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            msgQueue.Enqueue("body_2");
        }
#endif
    }

    #region Recieve the Signal

    public void OpenPort()
    {
  
        sp = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
        sp.ReadTimeout = 400;
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

            
            if (this.sp != null && this.sp.IsOpen)
            {
                try
                {
                    String strRec = sp.ReadLine();
                    
                    if(currentTime > coolTime)
                    {
                        Debug.Log(strRec);
                        currentTime = 0;
                        msgQueue.Enqueue(strRec);
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
    public void RecieveSignal(string hitMsg)
    {
        
        int index = hitMsg.IndexOf('_');
        int msgLength = hitMsg.Length;
        Body body = (Body)Enum.Parse(typeof(Body),hitMsg.Substring(0, index));
      
        int player_index = int.Parse(hitMsg.Substring(index + 1, msgLength - index - 1));
        switch (status)
        {
            case GameStatus.ready:
            case GameStatus.over:
                if (body == Body.body)
                {
                    if (player_index == 1)
                    {
                        if(status == GameStatus.ready)
                        startMenu.SelectPlayer(1);
                        ready_1 = true;
                    }
                    else if (player_index == 2)
                    {
                        if (status == GameStatus.ready)
                            startMenu.SelectPlayer(2);
                        ready_2 = true;
                    }
                }
                break;
            case GameStatus.block: break;
            
            case GameStatus.fighting: BloodEvents(body, player_index); break;
        }
        
   

    }

    private void OnDestroy()
    {
        if (receiveThread != null)
        {
            receiveThread.Abort();
        }
        
        if(sp != null)
        {
            sp.Close();
        }
        
    }
  
    private void StartGame() {
        SceneManager.LoadScene("Main_boxingRing");
    }


    private void RestartGame()
    {
        
        SceneManager.LoadScene("Main_boxingRing");
    }
}