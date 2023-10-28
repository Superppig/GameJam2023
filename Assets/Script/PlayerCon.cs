using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    [Header("基础属性")]
    public float health;//生命值
    public float speed;//速度
    [Header("击飞敌人")] 
    public float maxHitRange;//
    public float maxHitTime;//最大蓄力值
    private float time = 0f;

    private Vector2 moveDir;

    private Rigidbody2D rb;
    private Collider2D cl;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
    }
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerInput()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;
            time = time < maxHitTime ? time : maxHitTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //输出蓄力值
            Debug.Log(time/maxHitTime);
            HitEnemy();
        }
    }

    void PlayerMove()
    {
        rb.velocity = moveDir * speed;
    }

    void HitEnemy()
    {
    }
}
