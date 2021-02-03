using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ : MonoBehaviour
{
    public GameObject a0;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;

    public AudioSource m1;
    public AudioSource m2;
    public AudioSource m3;
    public AudioSource m4;

    private Quaternion qqq;

    public void death(Vector3 wwww ,float mmn)  
    {
        audiopaly();
        if (mmn == 1)
        {
              qqq = new Quaternion(0,0,0,1);
        }
        else
        {
              qqq = new Quaternion(0, 1, 0, 0);
        }
        

        int val = Random.Range(0, 4); //随机函数
        if (val == 0)
        {
            Instantiate(a0, wwww,qqq);
        }
        if (val == 1)
        {
            Instantiate(a1, wwww,qqq);
        }
        if (val == 2)
        {
            Instantiate(a2, wwww,qqq);
        }
        if (val == 3)
        {
            Instantiate(a3, wwww,qqq);
        }

    }


    void audiopaly()
    {
        int val = Random.Range(0, 4);
        if (val == 0)
        {
            m1.Play();
        }
        if (val == 1)
        {
            m2.Play();
        }
        if (val == 2)
        {
            m3.Play();
        }
        if (val == 3)
        {
            m4.Play();
        }
    }
}
