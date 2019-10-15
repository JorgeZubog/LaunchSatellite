using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameObject earth;


    public Vector3 gravityVectory;
    // Start is called before the first frame update
    void Start()
    {
        earth =GameObject.Find("Earth");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference  = earth.transform.position - this.transform.position;
        float dist = difference.magnitude;
        Vector3 gravityDirection =difference.normalized;
        float gravity = 6.7f * (earth.transform.localScale.x * this.transform.localScale.x * 80) / (dist*dist);
        gravityVectory = (gravityDirection * gravity);
            //orbiter.transform.GetComponent<Rigidbody>().AddForce(orbiter.transform.forward, ForceMode.Acceleration);
        transform.GetComponent<Rigidbody>().AddForce(gravityVectory, ForceMode.Acceleration);
    }

}
