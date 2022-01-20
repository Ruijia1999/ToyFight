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
    private Thread receiveThread;  //用于接收消息的线程
    public string portName = "COM3";//串口名，根据自己arduino板子的串口号写
    public int baudRate = 9600;//波特率
    public Parity parity = Parity.None;//效验位
    public int dataBits = 8;//数据位
    public StopBits stopBits = StopBits.One;//停止位

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
    }

    #region 创建串口，并打开串口
    public void OpenPort()
    {
        //创建串口
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
    #region 程序退出时关闭串口
    void OnApplicationQuit()
    {
        ClosePort();
    }

    public void ClosePort()
    {
        try
        {
            sp.Close();
            receiveThread.Abort();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    #endregion
    private void ReceiveThreadfunction()
    {
        while (true)
        {
            
            if (this.sp != null && this.sp.IsOpen)
            {
                try
                {
                    String strRec = sp.ReadLine();            //SerialPort读取数据有多种方法，我这里根据需要使用了ReadLine()
                    Debug.Log(strRec);
                    if (strRec.Equals("255"))
                    {
                        Debug.Log("is touched");
                    }
                }
                catch
                {
                    //continue;
                }
            }
        }
    }

}