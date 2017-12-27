using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong3D
{

    public class PlayerController : MonoBehaviour
    {

        //Use Vector3 to avoid extra crap
        [HideInInspector]
        public Vector3 InputDir = Vector3.zero;



        //Using a float for fine tuned control
        public float Speed = 1.0f;

        //Drop down list in the inspector
        public enum InputMethod
        {
            Player1,
            Player2,
            Bot
        };
        public InputMethod _InputMethod = InputMethod.Player1;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        // but FixedUpdate is different, it doesn't care about your frame rate
        void FixedUpdate()
        {
            Transform CurrentTransform = this.transform;

            if (_InputMethod == InputMethod.Player1)
            {
                InputDir.y = Input.GetAxis("Player 1") * Speed * Mathf.Min(1, Speed / 2);

                CurrentTransform.position += InputDir * Time.deltaTime;
                
            }
        }
    }
}