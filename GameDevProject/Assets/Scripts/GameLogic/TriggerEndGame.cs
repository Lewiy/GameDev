using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerEndGame : MonoBehaviour {


    private bool endGame;


    void OnTriggerEnter2D(Collider2D other)
    {

        //GUIText massege = this.gameObject.AddComponent<GUIText>();
        endGame = true;
      // WaitForSeconds deley  = new WaitForSeconds(10);
       StartCoroutine(Example());
       SceneManager.LoadScene("Scenes");
       // OnGUI();


    }

    void OnGUI()
    {
        if(endGame)
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Messege");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(400000);
        print(Time.time);
       
    }
}
