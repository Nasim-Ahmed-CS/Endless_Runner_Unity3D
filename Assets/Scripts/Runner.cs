using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
public class Runner : MonoBehaviour
{
    public bool flag = false;
    private CharacterController controller;
    
    
    private float _speed = 2.5f;
    public static int _score = 0;
    private float _jumpForce = 3.5f;
    private float _gravity = -6.81f;
    private Vector3 direction;

    public static float _energy = 10;

   

    AudioSource _coinSound;



    Animation anim;

    void Start()
    {
        
        anim = GetComponent<Animation>();
        _coinSound = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        transform.position = new Vector3(0, 0, -15);
    }

    // Update is called once per frame
    void Update()
    {

        

        direction.z = _speed;

        float horizontalInput = Input.GetAxis("Horizontal");

        direction.x = _speed * horizontalInput;

        controller.Move(direction * Time.deltaTime);


        if (transform.position.y == 0)
        {
            //direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jump();
            }
        }
        else if(transform.position.y > 0)
        {
            direction.y += _gravity * Time.deltaTime;
        }

        


        if(transform.position.x > 3.4f)
        {
            transform.position = new Vector3(3.4f, transform.position.y, transform.position.z);
        }

        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            direction.y = 0;
        }

        if (transform.position.x < -3.4f)
        {
            transform.position = new Vector3(-3.4f, transform.position.y, transform.position.z);
        }

        _energy -= (Time.deltaTime / 5);

        if(_energy < 0)
        {
            anim.Stop();
            PlayerManager.gameOver = true;
        }

    }

    


    private void jump()
    {
        direction.y = _jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Coin")
        {
            _coinSound.Play();
            _score += 5;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Block")
        {
            direction.y = 0;
            direction.z = 0;
            direction.x = 0;
            _speed = 0;

            anim.Stop();
            PlayerManager.gameOver = true;

        }
        
        
        else if(other.gameObject.tag == "Bottle_Endurance")
        {
            float e_val = _energy + 9.5f;
            if(e_val > 10)
            {
                _energy = 10;
            }
            else
            {
                _energy = e_val;
            }
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag == "Bottle_Mana")
        {
            _score += 50;
            Destroy(other.gameObject);
        }
        

    }
    
}
