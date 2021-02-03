using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DG : MonoBehaviour
{
    private Animator player;
    private GameObject other1;
    private Transform player1;

    public int aa;

    private void Awake()//bug
    {
        
        player = GameObject.Find("阿尔法").GetComponent<Animator>();
        player1 = GameObject.Find("阿尔法").transform;
    }
    private void OnEnable()  ///每次运行时，调用
    {
        //刀光 位置 方向
        transform.position = player1.position;
        transform.localScale = new Vector3(player1.localScale.x, 1, 1);

        Invoke("poolemmmm", 1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            other.gameObject.SendMessage("die",transform.position.x);

            //击退
            float m1 = transform.localScale.x;
            if (m1 == 1)
            {
                other.transform.position += new Vector3(0.5f, 0, 0);

            }
            else
            {
                other.transform.position += new Vector3(-0.5f, 0, 0);

            }
            //血的方向
            GameObject.Find("零位置&工具").GetComponent<GJ>().death(other.transform.position, transform.localScale.x);

            //顿帧1
            player.speed = 0;
            other.GetComponent<Animator>().speed = 0;
            other1 = other.gameObject;
;            Invoke("normal",0.15f);
        }
    }

    //顿帧2
    void normal()
    {
        player.speed = 1;
        other1.GetComponent<Animator>().speed = 1;
    }

    //对象池回收
    void poolemmmm()
    {
        var pool = objectPool.pool;
        if (aa == 0)
        {
            pool.poolOFF(pool.topool0, gameObject);
        }
        else if (aa == 1)
        {
            pool.poolOFF(pool.topool1, gameObject);
        }
        else
        {
            pool.poolOFF(pool.topool2, gameObject);
        }
    }

}
