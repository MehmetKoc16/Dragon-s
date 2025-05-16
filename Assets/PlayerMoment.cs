using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    Rigidbody2D rigidbody1;
    Animator playerAnimator;
    Vector3 velocity;
    float JumpForce = 4.5f;
    float speed = 3f;
    float points = 0f;
    float diamondAmount = 0;
    
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody1 = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        MovementControl();
        Debug.Log(points);
        if (GetComponent<CircleCollider2D>().IsTouching(GameObject.FindWithTag("Enemy").GetComponent<CapsuleCollider2D>()))
        {
            StartCoroutine(DamageEffect());
        }
    }
    IEnumerator DamageEffect()
    {
        for (int i = 0; i < 8; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Diamond")
        {
            Destroy(collision.gameObject);
            points += 50;
            diamondAmount++;
        }
    }
    private void MovementControl()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += velocity * Time.deltaTime * speed;
        if (Input.GetButtonDown("Jump") && rigidbody1.velocity.y == 0)
        {
            rigidbody1.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            playerAnimator.SetBool("IsJumping", true);
        }
        if (playerAnimator.GetBool("IsJumping") && rigidbody1.velocity.y == 0)
        {
            playerAnimator.SetBool("IsJumping", false);
        }
        bool playerHasHorizontalSpeed = Mathf.Abs(velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("IsRunning", playerHasHorizontalSpeed);
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1);
        }
    }

    public float GetDiamondAmount()
    {
        return diamondAmount;
    }
    public BoxCollider2D GetFeetColliderOfPlater()
    {
        return boxCollider2D;
    }
}
