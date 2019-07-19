using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public BoxCollider2D box;
    public float changeSec;
    public float moveSpeed;
    public bool isLeft;
    public GameObject blood;
    public bool noAnim;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (!noAnim)
        {
            animator = gameObject.GetComponent<Animator>();
            animator.SetBool("Move", true);
        }
        StartCoroutine("ChangeMove");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveVelocity = new Vector3();
        if (isLeft == true)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveSpeed * moveVelocity * Time.deltaTime;

    }
    //private void ontriggerenter2d(collider2d collision)
    //{
    //    if(collision.gameobject.tag == "player" && box.istrigger)
    //    {
    //        playermove playermove = collision.gameobject.getcomponent<playermove>();
    //        playermove.die();
    //    }
    //}
    public void Die()
    {
        StartCoroutine("DieCoroutine");
    }
    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        PlayerPrefs.SetInt("Kill", PlayerPrefs.GetInt("Kill") + 1);
        Destroy(this.gameObject);
    }
    IEnumerator ChangeMove()
    {
        yield return new WaitForSeconds(changeSec);
        isLeft = !isLeft;
        StartCoroutine("ChangeMove");
    }
}
