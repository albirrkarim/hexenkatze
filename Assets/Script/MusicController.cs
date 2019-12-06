using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Toggle onOffMusic;
    // Start is called before the first frame update
    void Start()
    {  
        if(!PlayerPrefs.HasKey("isUseMusic")){
            PlayerPrefs.SetInt("isUseMusic",1);
        }

        if(PlayerPrefs.GetInt("isUseMusic")==1){
			onOffMusic.isOn=true;
            PlayerPrefs.SetInt("isUseMusic",1);
		}else{
            onOffMusic.isOn=false;

            PlayerPrefs.SetInt("isUseMusic",0);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
