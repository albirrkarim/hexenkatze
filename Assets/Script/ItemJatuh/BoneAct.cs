using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneAct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float range = 7;
        float x=GameObject.FindGameObjectWithTag("Player").transform.position.x- range * Random.value;
        float y=GameObject.FindGameObjectWithTag("Player").transform.position.y+10;

        Vector2 veloc  = new Vector2(x,y);
        transform.position=veloc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll){
        // if(coll.gameObject.tag=="tanahTag"){
        //     Debug.Log("Hapus");
            Destroy(gameObject);
        // }
    }
}
