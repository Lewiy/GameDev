
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {


    public BounceControler selectedBounce { get; set; }
    public Vector3 direction;
    private Vector3 curs;


  //  private Vector3 offset;

	// Use this for initialization
	void Start () {
        //offset = transform.position - selectedBounce.transform.position;
       // Debug.Log("LOXXXXX");
       // Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();

       // cam.transform.position.Set(cam.transform.position.x + 18, cam.transform.position.y, cam.transform.position.z);
	}
	
    
 
	// Update is called once per frame
    void Update()
    {
        
        captureBounce();

        releaseBounce();

       // moveCamera();

        //triger = bo
       
        
    }
/*
   private void moveCamera()
   {
       transform.position = selectedBounce.transform.position + offset;
   }*/

    void captureBounce()
    {
        getPositionCursor();
        if (Input.GetMouseButtonDown(0))
              {

                  if (selectedBounce == null)
                   {
             Collider2D[] all = Physics2D.OverlapCircleAll((Vector2)curs, 0.2F);

              foreach (var colider in all)
               {
                  Debug.Log(colider.name);
                 if (colider.GetComponent<BounceControler>())
                  {
                     selectedBounce = colider.GetComponent<BounceControler>();
                 }
               }
           }
            }
        }

    void releaseBounce()
    {


        if (Input.GetMouseButtonUp(0))
        { // Fire!

            if (selectedBounce != null)
            {
                direction = -(curs - selectedBounce.CurrentPosition);
               // SelectedBounce.GetComponent<Rigidbody2D>().isKinematic = false;
                selectedBounce.releasedBounce(curs,direction);
                selectedBounce = null;
            }

        }
    }

    private void getPositionCursor()
    {
        curs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
