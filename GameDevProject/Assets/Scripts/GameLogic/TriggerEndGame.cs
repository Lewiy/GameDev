using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class TriggerEndGame : MonoBehaviour {


    private bool endGame;
    private GUIStyle guiStyle = new GUIStyle();

    void OnTriggerEnter2D(Collider2D other)
    {

        //GUIText massege = this.gameObject.AddComponent<GUIText>();
        endGame = true;
      // WaitForSeconds deley  = new WaitForSeconds(10);
       StartCoroutine(lateCall());
   
       // OnGUI();


    }

    void OnGUI()
    {

        if(endGame){
             guiStyle.fontSize = 29;
             GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100f, 800f), "The end",guiStyle);
        }
       
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    IEnumerator lateCall()
    {
        print("Time  - - - "+Time.time);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scenes");
        print(Time.time);
       
    }
}
