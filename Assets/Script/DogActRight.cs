using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogActRight : MonoBehaviour
{
    float speed;
    public int animCounter = 0;
    Animator animator;
    int nyawa=4;
    bool canJump=true;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        animator= GetComponent<Animator>();
        animator.SetInteger("dogAnim",2);
        transform.position -= transform.right * speed * Time.deltaTime;
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    IEnumerator jumpAgain()
    {
        yield return new WaitForSeconds(Random.Range(1.0f,4.0f));
        canJump=true;
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"||coll.gameObject.tag=="dogTag"){
            Destroy(gameObject);
            
        }else if(coll.gameObject.tag=="cherryTag"){
            nyawa-=PlayerPrefs.GetInt("attackPower");
            if(nyawa<=0){
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
        if(canJump){
            Vector2 jumpForce = new Vector2(0, Random.Range(100,300));
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.9f);
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            canJump=false;
            StartCoroutine(jumpAgain());
        }
    }
}
