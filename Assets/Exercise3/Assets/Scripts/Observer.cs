using System;
using UnityEngine;

namespace Exercise3.Assets.Scripts
{
    public class Observer: MonoBehaviour
    {
        public float speed = 100f;
        public float mouseSensitivity = 50f;
        private Vector2 turn;
       


        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            // move
            if(Input.GetKey(KeyCode.DownArrow)||(Input.GetKey(KeyCode.S)) )
            {
                transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
            }
            if(Input.GetKey(KeyCode.UpArrow)||(Input.GetKey(KeyCode.W)) )  
            {
                transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
            }
            
         


            turn.x += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
            
          
            
           
           
        }
    }
}