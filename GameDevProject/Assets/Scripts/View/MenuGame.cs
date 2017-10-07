using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour {


    public void OnClickStart()
    {
        SceneManager.LoadScene("FirstLaba");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
