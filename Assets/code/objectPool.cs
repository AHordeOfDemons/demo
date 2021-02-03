using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    public static objectPool pool;

    public Queue<GameObject> topool0 = new Queue<GameObject>();
    public GameObject otp0;

    public Queue<GameObject> topool1 = new Queue<GameObject>();
    public GameObject otp1;

    public Queue<GameObject> topool2 = new Queue<GameObject>();
    public GameObject otp2;
    void Awake()
    {
        pool = this;
    }


    public void poolON(Queue<GameObject> topool, GameObject otp)    //生成，激活
    {
        if (topool.Count == 0)
        {
            Instantiate(otp);
        }
        else
        {
            topool.Dequeue().SetActive(true);
        }
    }

    public void poolOFF(Queue<GameObject> topool, GameObject otp)   //关闭，进入队列
    {
        otp.SetActive(false);
        topool.Enqueue(otp);
    }
}
