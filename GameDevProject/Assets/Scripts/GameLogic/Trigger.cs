using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    private float speed = 3;
    private Camera cam;
    private bool moveCameraFlag;
    private float distance;

  //  void Trigger(GameObject game){
        //game.transform.position.x = Vector3(0.0512155, 0.5632893, 5.466473);
       // Camera.main.transform.position.Set(Camera.main.transform.position.x + 18, Camera.main.transform.position.y, Camera.main.transform.position.z);
 //  }

   void OnTriggerEnter2D(Collider2D other)
    {
        moveCameraFlag = true;
        distance += 18;

    
    }



    public void  MoveCamera()
    {
        cam.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (cam.transform.position.x < distance && moveCameraFlag == true)
            MoveCamera();
	}
}
