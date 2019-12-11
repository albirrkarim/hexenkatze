using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItem : MonoBehaviour
{
    public GameObject Bone;
    public GameObject SwordPlus;
    public GameObject SwordMin;
    public GameObject Fish;
    public GameObject CatFood;
    public GameObject Dog;
    public GameObject Dogkanan;

    // Start is called before the first frame update
    void Start()
    {  
        if(!PlayerPrefs.HasKey("whatLevel")){
			PlayerPrefs.SetInt("whatLevel",1);
		}
        int level=PlayerPrefs.GetInt("whatLevel");

        if(level==3){
            /* Level Hard */
            InvokeRepeating ("CreateBone",1f,2.0f);
            InvokeRepeating ("CreateSwordPlus",4f,2.0f);
            InvokeRepeating ("CreateSwordMin",3f,3.0f);
            InvokeRepeating ("CreateFish",2.5f,3.0f);
            InvokeRepeating ("CreateCatFood",6f,5.0f);
            InvokeRepeating ("CreateDog",4f,3.0f);
            InvokeRepeating ("CreateDogKanan",3f,2.0f);
        }else if(level ==2){
            /* Level Medium */
             InvokeRepeating ("CreateBone",2f,3.0f);
            InvokeRepeating ("CreateSwordPlus",6f,4.0f);
            InvokeRepeating ("CreateSwordMin",6f,6.0f);
            InvokeRepeating ("CreateFish",3f,5.0f);
            InvokeRepeating ("CreateCatFood",7f,8.0f);
            InvokeRepeating ("CreateDog",8f,5.0f);
            InvokeRepeating ("CreateDogKanan",6f,8.0f);
        }else{
            
            /* Level Easy */
            InvokeRepeating ("CreateBone",4f,3.0f);
            InvokeRepeating ("CreateSwordPlus",6f,4.0f);
            InvokeRepeating ("CreateSwordMin",6f,6.0f);
            InvokeRepeating ("CreateFish",4f,4.0f);
            InvokeRepeating ("CreateCatFood",8f,8.0f);
            InvokeRepeating ("CreateDog",9f,8.0f);
            InvokeRepeating ("CreateDogKanan",7f,7.0f);
        }
    }
    void CreateBone (){
        Instantiate(Bone);
    }

    void CreateSwordPlus (){
        Instantiate(SwordPlus);
    }

    void CreateSwordMin (){
        Instantiate(SwordMin);
    }


    void CreateFish (){
        Instantiate(Fish);
    }

    void CreateCatFood (){
        Instantiate(CatFood);
    }

    void CreateDog (){
        Instantiate(Dog);
    }
    void CreateDogKanan (){
        Instantiate(Dogkanan);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
