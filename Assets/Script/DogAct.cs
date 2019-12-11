using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAct : MonoBehaviour
{
    Transform target;
    float speed;
    public int animCounter = 0;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        animator= GetComponent<Animator>();
        animator.SetInteger("dogAnim",2);
        transform.position += transform.right * speed * Time.deltaTime;
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"){
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right *speed * Time.deltaTime;
    }
}