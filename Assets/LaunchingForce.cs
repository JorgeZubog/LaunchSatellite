using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingForce : MonoBehaviour
{

    public bool launch = false;
    public bool isLaunched = false;

    private bool scanning = false;
    float magnitud = 1800;

    public GameObject earth;
    public GameObject capsule;

    LaunchingInteraction interaction; 
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<LaunchingInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(-interaction.delta.x, 0, interaction.delta.y) * (magnitud/1000), Color.green);
        
        if(GetComponentInChildren<LineRenderer>().enabled)
        {
            Vector3[] positions = new Vector3[] {Vector3.zero, new Vector3(-interaction.delta.x, 0, interaction.delta.y) * 15};
            GetComponentInChildren<LineRenderer>().SetPositions(positions);
        }
        

        Vector3 difference = Vector3.Normalize(earth.transform.position - this.transform.position);

        velocity = Vector3.Cross(difference, this.transform.up);

        Debug.DrawLine(transform.position, transform.position + velocity, Color.red);
        if(scanning)
        {
            var scan = GameObject.Instantiate(capsule, transform.position, transform.rotation);
            scan.GetComponent<Scanner>().earth = this.earth;
            scan.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(earth.transform.position - this.transform.position)*magnitud, ForceMode.Acceleration);
            

            scan.GetComponent<Rigidbody>().AddForce(velocity*(magnitud/5), ForceMode.Acceleration);

            scanning =false;
        }
    }






    public void Launch(){
        if(isLaunched == false)
        {
            launch = true;
            this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(interaction.delta.x, 0, -interaction.delta.y)*2f*magnitud, ForceMode.Acceleration);
            isLaunched = true;
        }
    }

    public void Scan(){
        scanning = true;
    }

    public void Scan(Vector3 delta){
        var scan = GameObject.Instantiate(capsule, transform.position, transform.rotation);
            scan.GetComponent<Scanner>().earth = this.earth;
            scan.GetComponent<Rigidbody>().AddForce(new Vector3(delta.x, 0, -delta.y)*2f*magnitud, ForceMode.Acceleration);
            

            scan.GetComponent<Rigidbody>().AddForce(velocity*(magnitud/5), ForceMode.Acceleration);
    }

    internal void ActiveDirection(bool active)
    {
        Vector3[] positions = new Vector3[] {Vector3.zero, Vector3.zero};
        GetComponentInChildren<LineRenderer>().SetPositions(positions);
        GetComponentInChildren<LineRenderer>().enabled = active;
    }
}
