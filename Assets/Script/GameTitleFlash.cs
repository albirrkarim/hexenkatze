using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitleFlash : MonoBehaviour
{
    IEnumerator NextFlash() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextFlash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
