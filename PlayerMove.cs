using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool jumpLock = false;
    bool canAtk = true;
    bool atk;
    int jumpcount;
    public int nextmap;
    public bool haveKey;
    public bool canJump;
    public GameObject ending;
    public bool noAnim;
    public Animator animator;
    public bool sadarible;
    public BoxCollider2D box;
    public BoxCollider2D box2;
    public float moveSpeed;
    public float jumpPower;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
  
        jumpcount = 0;
            animator = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();


    }
    void FixedUpdate()
    {
        Move();
        Jump();
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
        ATK();
        if(sadarible)
        SadariMove();
    }
    // Update is called once per frame
    void Move()
    {
        Vector3 moveVelocity = new Vector3();
        moveVelocity.Set(Input.GetAxisRaw("Horizontal"), 0, 0);
        if (Input.GetAxisRaw("Horizontal") != 0 && !noAnim)
        {
            animator.SetBool("Move", true);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if (!sadarible && Input.GetAxisRaw("Vertical") < 0)
        {
            animator.SetBool("Gear", true);
            box2.enabled = true;
            box.enabled =false;
            jumpLock = true;
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            
            animator.SetBool("Gear", false);
            StartCoroutine("BoxEnd");
            jumpLock = false;
        }
        moveVelocity = moveVelocity.normalized * moveSpeed * Time.deltaTime;
        rigid.MovePosition(transform.position + moveVelocity);

    }
    void SadariMove()
    {
        Vector3 moveVelocity2 = new Vector3();
        if (Input.GetAxisRaw("Vertical") >0)
            moveVelocity2 = Vector3.up;
        else if (Input.GetAxisRaw("Vertical") <0)
            moveVelocity2 = Vector3.down;
        transform.position += moveVelocity2 * moveSpeed * Time.deltaTime;

    }
    void ATK()
    {

        if(Input.GetButtonDown("atk") && canAtk)
        {
            animator.SetBool("ATK", true);
            canAtk = false;
            StartCoroutine("AtkCoroutine");
        }
    }

    void Jump()
    {
        if (jumpcount < 2 && Input.GetButtonDown("Jump") && !jumpLock)
        {
            jumpcount++;

            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);




        }
    }


    public void Die()
    {
        
        animator.SetBool("Die", true);

        StartCoroutine("DieCoroutine");
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(0.45f);
        animator.SetBool("Die", false);
        SceneManager.LoadScene(nextmap-1);
    }
    IEnumerator AtkCoroutine()
    {
        atk = true;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("ATK", false);
        atk = false;
        yield return new WaitForSeconds(0.05f);
        canAtk = true;

    }

    IEnumerator BoxEnd()
    {
        yield return new WaitForSeconds(0.21f);
        box2.enabled = false;
        box.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster" && atk)
        {
            if (haveKey)
            {
                MonsterMove mob = other.gameObject.GetComponent<MonsterMove>();
                Animator newnim = mob.blood.GetComponent<Animator>();
                newnim.SetBool("Blood", true);
                mob.Die();
            }
           
        }
       
        if (other.gameObject.tag == "Ground")
            jumpcount = 0;
        if (other.gameObject.tag == "GASHI")
            Die();
        
        if (other.gameObject.tag == "DOOR")
        {
            if (haveKey == true)
            {
                BoxCollider2D box;
                box = other.gameObject.GetComponent<BoxCollider2D>();
                box.enabled = false;
                Animator sanimator = other.gameObject.GetComponent<Animator>();
                sanimator.SetBool("OPEN", true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SADARI")
        {
            box.enabled = false;
            box2.enabled = false;
            sadarible = true;
            rigid.gravityScale = 0f;
        }
        if (collision.gameObject.tag == "Monster" && collision.isTrigger)
        {
           
                Die();
        }
        if (collision.gameObject.tag == "LAVER" && atk)
        {
            Animator banimator = collision.gameObject.GetComponent<Animator>();
            Laver layerr = collision.gameObject.GetComponent<Laver>();
            layerr.Deto();
            banimator.SetBool("On", true);
        }
        if (collision.gameObject.tag == "KEY")
        {
            haveKey = true;
            Destroy(collision.gameObject);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoMul")
        {
            if (nextmap == 4)
            {
                ending.SetActive(true);
            }
            else
            {

                SceneManager.LoadScene(nextmap);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SADARI")
        {
            
            box.enabled = true;
            box2.enabled = false;
            sadarible = false;
            rigid.gravityScale = 3.6f;
        }
    }

}

    


   


