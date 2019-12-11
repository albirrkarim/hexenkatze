using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text teksHighscore;
	// Use this for initialization
	void Start () {
		teksHighscore.text = LoadHighscore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static int LoadHighscore(){
		if(!PlayerPrefs.HasKey("attackPower")){
			PlayerPrefs.SetInt("attackPower", 0);
			return 0;
		}
		else{
			return PlayerPrefs.GetInt("attackPower");
		}
	}
}
