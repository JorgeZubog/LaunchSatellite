using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public GameObject earth;
    public LaunchingForce launching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(launching.isLaunched)
            transform.RotateAround(earth.transform.position, Vector3.up, 10 * Time.deltaTime);
    }
}
