using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitters : MonoBehaviour
{
    public GameObject orbiter;
    public Vector3 gravityVectory;

    public GameObject capsule;

    bool isGravityActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGravityActive)
        {
            Vector3 difference  = this.transform.position - orbiter.transform.position;
            float dist = difference.magnitude;
            Vector3 gravityDirection =difference.normalized;
            float gravity = 6.7f * (this.transform.localScale.x * orbiter.transform.localScale.x * 80) / (dist*dist);
            gravityVectory = (gravityDirection * gravity);
            //orbiter.transform.GetComponent<Rigidbody>().AddForce(orbiter.transform.forward, ForceMode.Acceleration);
            orbiter.transform.GetComponent<Rigidbody>().AddForce(gravityVectory, ForceMode.Acceleration);
        }
        
    }

    public void ActiveGravity(){
        isGravityActive = true;
    }

    private void OnTriggerEnter(Collider other) {
            if(other.gameObject.name == "Capsule(Clone)")
                GameObject.Destroy(other.gameObject);
    }
}
