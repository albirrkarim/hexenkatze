using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryActRight : MonoBehaviour
{
     float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed=5;
        GameObject Player=GameObject.FindGameObjectWithTag("Player");
        transform.position=new Vector2(Player.transform.position.x -1.7f,Player.transform.position.y);
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="dogTag"){
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right *speed * Time.deltaTime;
    }
}
