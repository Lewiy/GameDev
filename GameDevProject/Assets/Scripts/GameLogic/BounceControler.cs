using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceControler : MonoBehaviour
{

    public Vector3 StartPosition { get; set; }
    public Vector3 CurrentPosition { get; set; }
    //public float distanceTension = 0;
    public Vector3 direction;
    private const float distanceTensionConst = 2.0F;
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
        float distanceTension = Vector3.Distance(new Vector2(curs.x, curs.y), this.CurrentPosition);

        distanceTension = normalizeTension(distanceTension);
        this.direction = direction;
        this.GetComponent<Rigidbody2D>().AddForceAtPosition(
                   (direction * distanceTension * 200),
                  this.CurrentPosition);
    }

    private float normalizeTension(float distanceTension)
    {
        if (distanceTension > 2.0)
            return distanceTensionConst;
        else return distanceTension;
    }
}
