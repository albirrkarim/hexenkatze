using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UnityLogoFlash : MonoBehaviour
{

    IEnumerator NextFlash() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameTitleFlash");
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
