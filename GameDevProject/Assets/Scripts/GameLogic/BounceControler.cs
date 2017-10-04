using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceControler : MonoBehaviour
{

    public Vector3 StartPosition { get; set; }
    public Vector3 CurrentPosition { get; set; }
    // Use this for initialization
    void Start()
    {
        CurrentPosition = StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPosition = transform.position;
    }

    public void releasedBounce(Vector3 curs, Vector3 direction)
    {
        this.GetComponent<Rigidbody2D>().AddForceAtPosition(
                   direction * Vector3.Distance(new Vector2(curs.x, curs.y), this.CurrentPosition) * 300,
                  this.CurrentPosition);
    }
}
