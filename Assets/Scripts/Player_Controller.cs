using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed = 3f;
    float velX;
    float velY;
    bool facingRingth = true;
    private Rigidbody2D rigiBody;
    Animator anim;
    bool caminar = false;
    public float jumpPower = 6.5f;
    private bool jump;


 //variable publica que permite acceder al animator desde este script
	// Use this for initialization
	void Start () 
	{
        rigiBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        //control de teclado
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigiBody.velocity.y;
        rigiBody.velocity = new Vector2(velX * moveSpeed, velY);

        if(velX!=0)
        {
            caminar = true;
        }
        else
        {
            caminar = false;
        }
        anim.SetBool("caminar", caminar);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;

        }
    }

    void FixedUpdate()
    {
        if(jump)
        {
            rigiBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

    }
}
