using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogActRight : MonoBehaviour
{
    float speed;
    public int animCounter = 0;
    int isCollide=0;
    Animator animator;
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
        // print(Time.time);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        // print(Time.time);
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Player"){
            animCounter=1;
            isCollide=1;
            kurangiLifePlayer();
            animator.SetInteger("dogAnim",animCounter);
        }
        else if(coll.gameObject.tag=="dogTag"){
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Player"){
            animCounter=0;
            isCollide=0;
            animator.SetInteger("dogAnim",animCounter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollide==0){
            animCounter=2;
            animator.SetInteger("dogAnim",animCounter);
        }
        transform.position -= transform.right * speed * Time.deltaTime;
    }

    void kurangiLifePlayer(){
        int currentLife = PlayerPrefs.GetInt("playerLife",0);
        currentLife--;
        PlayerPrefs.SetInt("playerLife",currentLife);
        Destroy(gameObject);
    }


}
