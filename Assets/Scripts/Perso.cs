using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Perso : DualBehaviour 
{
    #region Public Members

    public float m_movementSpeed;
    public float jumpImpulse;

    #endregion

    #region Public void



    #endregion

    #region System

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
        m_transform = GetComponent<Transform>();
        m_rigidebody2D = GetComponent<Rigidbody2D>();
    }
	
	void Update () 
    {
        GetInput();
        Move();
        Jump();
        UpdateAnimation();
    }

    #endregion

    #region Class Methods

    private void GetInput()
    {
        m_getAxis = (int)Input.GetAxisRaw("Horizontal");
        m_speed = m_getAxis;

    }

    private void UpdateAnimation()
    {
        m_animator.SetInteger("Move", m_speed);
        m_animator.SetBool("Jump", m_jump);
    }

    private void Move()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * m_movementSpeed, 0f, 0f);

    }

    private void Jump()
    {
       if (Input.GetButtonDown("Jump"))
        {
            m_jump = true;
            m_rigidebody2D.AddForce(new Vector2(0, jumpImpulse));
        }
        else
        {
            m_jump = false;
        }
    }

    #endregion

    #region Tools Debug and Utility



    #endregion

    #region Private and Protected Members

    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
    private Rigidbody2D m_rigidebody2D;

    private bool m_jump;
    private int m_speed;
    private int m_getAxis;

    #endregion

}
