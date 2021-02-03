using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    private AnimatorStateInfo animsta;

    public Transform aaw;

    public AudioSource m1;
    public AudioSource m2;
    public AudioSource m3;
    public AudioSource m4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        animsta = anim.GetCurrentAnimatorStateInfo(0);
    }
    void Update()
    {
        animplayer();
        IsTriggerAttack();
        //fired1();
    }
    private void FixedUpdate()
    {
        move();
    }




    void move()
    {
        float horizontalmove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        if (horizontalmove != 0)
        {
            transform.localScale = new Vector3(horizontalmove, 1, 1);
        }

    }
    void animplayer()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));     
    }

    void IsTriggerAttack()
    {

        if (Input.GetKey(KeyCode.J))
        {
            if (animsta.IsName("fire2") || animsta.IsName("fire1"))
            {
                if (animsta.normalizedTime > 0.7f)
                {
                    anim.SetBool("fire", true);
                }
            }
            else
            {
                anim.SetBool("fire", true);
            }
        }
        else
        {
              anim.SetBool("fire", false);

        }
    }


    void fireDG(int aa)
    {
        var pool = objectPool.pool;
        if(aa == 0)
        {
            pool.poolON(pool.topool0, pool.otp0);
        }
        else if (aa == 1)
        {
            pool.poolON(pool.topool1, pool.otp1);
        }
        else
        {
            pool.poolON(pool.topool2, pool.otp2);
        }
        

    }

    void fmove(float x)
    {
        transform.position += new Vector3(transform.localScale.x * x, 0, 0);


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

