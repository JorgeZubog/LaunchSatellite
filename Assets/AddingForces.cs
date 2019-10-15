using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingForces : MonoBehaviour
{
    public GameObject earth;
    public float constant = 0.2f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("down"))
        {
            this.transform.position = this.transform.position + Vector3.Normalize(earth.transform.position - this.transform.position)*constant;
        }
        if(Input.GetKey("up"))
        {
            this.transform.position = this.transform.position - Vector3.Normalize(earth.transform.position - this.transform.position)*constant;
        }
    }
}
