using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float giddyTime = 3f;
    Rigidbody2D rigidbody1;
    float velocity = 2f;
    CapsuleCollider2D capsuleCollider2D;
    bool isGiddy = false;
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if(capsuleCollider2D.IsTouching(FindObjectOfType<PlayerMoment>().GetFeetColliderOfPlater()))
        {
            StartCoroutine(BeGiddy());
        }
        if (isGiddy)
            return;
        rigidbody1.velocity=new Vector2(velocity, 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    { 
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody1.velocity.x)), 1);
       velocity = -velocity;
    }

    IEnumerator BeGiddy()
    {
        rigidbody1.velocity = new Vector2(0, 0);
        isGiddy = true;
        GetComponent<Animator>().SetBool("isGiddy", true);
        yield return new WaitForSeconds(giddyTime);

        if (velocity > 0)
        {
            transform.localScale=new Vector2(1,1);
        }
        GetComponent<Animator>().SetBool("isGiddy", false);
        isGiddy = false;

    }
}
