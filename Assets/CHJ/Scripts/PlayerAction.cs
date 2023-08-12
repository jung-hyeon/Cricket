using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    private Rigidbody2D rigid;
    [SerializeField] private float h;
    [SerializeField] private float v;
    [SerializeField] private bool isHorizonMove;

    private Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

        if (hDown || vUp)
        {
            isHorizonMove = true;
        }
        else if (vDown || hUp)
        {
            isHorizonMove = false;
        }


        //Animation
        /*if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChange", false);
        }*/
        if (anim.GetInteger("fAxisRow") != h)
        {
            anim.SetInteger("fAxisRow", (int)h);
            anim.SetTrigger("isChange");
        }
        else if (anim.GetInteger("vAxisRow") != v)
        {
            anim.SetInteger("vAxisRow", (int)v);
            anim.SetTrigger("isChange");
        }
    }
    private void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;
    }

    
}
