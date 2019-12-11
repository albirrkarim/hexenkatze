using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Image[] bone;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("whatLevel")){
			PlayerPrefs.SetInt("whatLevel",1);
		}
        whatLevel(PlayerPrefs.GetInt("whatLevel"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEasy(){
        PlayerPrefs.SetInt("whatLevel",1);
    }
    public void setMedium(){
        PlayerPrefs.SetInt("whatLevel",2);
    }
    public void setHard(){
        PlayerPrefs.SetInt("whatLevel",3);
    }

	public void whatLevel(int idx){
		for (int i = 0; i < 3; i++){   
            if(i<idx){
                bone[i].gameObject.SetActive(true);
            }else{
                bone[i].gameObject.SetActive(false);
            }
        }
	}
}
