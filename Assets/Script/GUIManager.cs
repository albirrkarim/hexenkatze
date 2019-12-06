using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {
	public Image[] bone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnToggleMusic(){
		if(!PlayerPrefs.HasKey("isUseMusic")){
            PlayerPrefs.SetInt("isUseMusic",1);
        }

		if(PlayerPrefs.GetInt("isUseMusic")==1){
			PlayerPrefs.SetInt("isUseMusic",0);
		}else{
			PlayerPrefs.SetInt("isUseMusic",1);
		}
	}

	public void OnMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	public void OnPause(){
		SceneManager.LoadScene("Pause");
	}

	public void OnResume(){
		PlayerPrefs.SetInt("isResume",1);
		SceneManager.LoadScene("PlayGame");
	}

	public void OnPlay(){
		if(!PlayerPrefs.HasKey("isFirstGame")){
			SceneManager.LoadScene("HowToPlay");
			PlayerPrefs.SetInt("isFirstGame",1);
		}else{
			SceneManager.LoadScene("PlayGame");
		}
	}

	public void OnLevelEasy(){
		PlayerPrefs.SetInt("whatLevel",1);
		whatLevel(1);
	}
	public void OnLevelMedium(){
		PlayerPrefs.SetInt("whatLevel",2);
		whatLevel(2);
	}
	public void OnLevelHard(){
		PlayerPrefs.SetInt("whatLevel",3);
		whatLevel(3);
	}
	
	public void whatLevel(int idx){
		int i;
		for (i = 0; i < 3; i++){   
            if(i<idx){
                bone[i].gameObject.SetActive(true);
            }else{
                bone[i].gameObject.SetActive(false);
            }
        }
	}


	public void OnOption(){
		SceneManager.LoadScene("Option");
	}

	public void OnLevel(){
		SceneManager.LoadScene("Level");
	}
	
	public void OnHowToPlay(){
		SceneManager.LoadScene("HowToPlay");
	}

	public void OnCredit(){
		SceneManager.LoadScene("Credit");
	}

	public void OnExit(){
		Application.Quit();
	}

	public void OnPlayerScore(){
		SceneManager.LoadScene("PlayerScore");
	}
}
