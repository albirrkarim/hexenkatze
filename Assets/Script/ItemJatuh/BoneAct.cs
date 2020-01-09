using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneAct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player=GameObject.FindGameObjectWithTag("Player");
        transform.position=new Vector2(Player.transform.position.x - 7 * Random.value,Player.transform.position.y+10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag!="cherryTag"){
            Destroy(gameObject);
        }
    }
}
