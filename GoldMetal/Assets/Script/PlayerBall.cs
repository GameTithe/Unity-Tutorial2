using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;

    bool isJump;
    Rigidbody rigid;
    AudioSource audio;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && !(isJump) )
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    } 
    void FixedUpdate()
    {
        
        float h = Input.GetAxisRaw("Horizontal");  //가로
        float v = Input.GetAxisRaw("Vertical");    //세로

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            isJump = false;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }

        else if (other.tag == "Finish")
        {
            if( itemCount == manager.totalItemCount)
            {
                //GameClear
                manager.stage = (manager.stage + 1) % 2;
                SceneManager.LoadScene(  manager.stage );
            }

            else
            {
                //Restart
                SceneManager.LoadScene(manager.stage);
            }
        }

    }
}
