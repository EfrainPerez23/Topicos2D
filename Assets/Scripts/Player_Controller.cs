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

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;

    public LayerMask whatIsEnemy;
    public int damage;

    private SpriteRenderer mySpriteRenderer;

    private GameObject health;


    //variable publica que permite acceder al animator desde este script
    // Use this for initialization
    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //control de teclado
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigiBody.velocity.y;
        rigiBody.velocity = new Vector2(velX * moveSpeed, velY);

        if (velX != 0)
        {
            caminar = true;
        }
        else
        {
            caminar = false;
        }
        anim.SetBool("caminar", caminar);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // flip the sprite
            this.mySpriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // flip the sprite
            this.mySpriteRenderer.flipX = true;
        }

        if (this.timeBtwAttack <= 0) {
            if (Input.GetKey(KeyCode.Space)) {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(this.attackPos.position, this.attackRange, this.whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(this.damage);
                }
            }
            this.timeBtwAttack = this.startTimeBtwAttack;
            
        } else {
            this.timeBtwAttack -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rigiBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

    }

    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.attackPos.position, this.attackRange);
    }
    
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Enemy") {
			--GetComponent<Health>().health;
            Destroy(other.gameObject);
            Debug.Log(GetComponent<Health>().health);
            if(GetComponent<Health>().health == 0) {
                Debug.Log("GAME OVER!!!!!");
            }
		}
    }
}
