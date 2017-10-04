
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {


    public BounceControler SelectedBounce { get; set; }
    public Vector3 direction;
	// Use this for initialization
	void Start () {
		
	}
	

 
	// Update is called once per frame
    void Update()
    {
        Vector3 curs = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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

        if (SelectedBounce != null)
        {
             direction =  - (curs - SelectedBounce.CurrentPosition);
           // SelectedBounce.transform.position = Vector3.MoveTowards(SelectedBounce.transform.position,
           //    new Vector2(curs.x,curs.y), Time.deltaTime * 10.0f);

        } 
        if (Input.GetMouseButtonUp(0))
        { // Fire!

            if (SelectedBounce != null)
            {
                SelectedBounce.GetComponent<Rigidbody2D>().isKinematic = false;

                SelectedBounce.GetComponent<Rigidbody2D>().AddForceAtPosition(
                     direction * Vector3.Distance(new Vector2(curs.x, curs.y), SelectedBounce.CurrentPosition) * 300,
                    SelectedBounce.CurrentPosition);
            }

        }
    }
}
