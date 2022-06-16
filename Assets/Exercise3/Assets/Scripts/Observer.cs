using UnityEngine;

namespace Exercise3.Assets.Scripts
{
    public class Observer: MonoBehaviour
    {
        private float speed = 25.0f;
        
        private void Update()
        {
            // rotate
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0,speed * Time.deltaTime,0));
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0,-speed * Time.deltaTime,0));
            }
            
            // move
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
            }
        }
    }
}