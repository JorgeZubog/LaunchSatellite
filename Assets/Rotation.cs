using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public float Radius = 12f;
 
    public Vector3 _centre = Vector3.zero;
    public float _angle;
 
     private void Start()
     {
         _centre = transform.position;
     }
 
     private void Update()
     {
 
         _angle += RotateSpeed * Time.deltaTime;
 
         var offset = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle)) * Radius;
         transform.position = _centre + offset;
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Capsule")
            Destroy(other.gameObject);
    }
}
