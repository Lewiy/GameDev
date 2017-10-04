
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {


    public BounceControler SelectedBounce { get; set; }
    public Vector3 direction;
    private Vector3 curs;
	// Use this for initialization
	void Start () {
		
	}
	

 
	// Update is called once per frame
    void Update()
    {
        

        
        captureBounce();

        releaseBounce();
        
    }

   

    void captureBounce()
    {
        getPositionCursor();
        if (Input.GetMouseButtonDown(0))
              {

                  if (SelectedBounce == null)
                   {
             Collider2D[] all = Physics2D.OverlapCircleAll((Vector2)curs, 0.2F);

              foreach (var colider in all)
               {
                  Debug.Log(colider.name);
                 if (colider.GetComponent<BounceControler>())
                  {
                     SelectedBounce = colider.GetComponent<BounceControler>();
                 }
               }
           }
            }
        }

    void releaseBounce()
    {


        if (Input.GetMouseButtonUp(0))
        { // Fire!

            if (SelectedBounce != null)
            {
                direction = -(curs - SelectedBounce.CurrentPosition);
               // SelectedBounce.GetComponent<Rigidbody2D>().isKinematic = false;
                SelectedBounce.releasedBounce(curs,direction);
              
            }

        }
    }

    private void getPositionCursor()
    {
        curs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
