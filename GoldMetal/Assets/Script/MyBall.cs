using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBall : MonoBehaviour
{

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //rigid.AddForce(Vector3.up * 10 , ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * 3 , ForceMode.Impulse);
        }
        
        Vector3 vec = new Vector3( Input.GetAxis("Horizontal") * Time.deltaTime * 15f , 0 , Input.GetAxis("Vertical")*Time.deltaTime*15f);
        
        rigid.AddForce(vec, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Cube")
        {
            rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);
        }
    }

    public void Jump()
    {
        rigid.AddForce(Vector3.up * 2, ForceMode.Impulse);

    }
}
