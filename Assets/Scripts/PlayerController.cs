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

        //Use an int to use less memory, and it wont change to anything with decimals, so we only need an int
        [HideInInspector]
        public int HalfHeight = 3;

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

        //Making things alot easier to change on the fly, just good practice
        [HideInInspector]
        public float TopWallY;
        [HideInInspector]
        public float BottomWallY;
        [HideInInspector]
        public string Axis;

        // Update is called once per frame
        // but FixedUpdate is different, it doesn't care about your frame rate
        public void FixedUpdate()
        {
            Transform CurrentTransform = this.transform;
            
            if (_InputMethod == InputMethod.Player1)
            {
                Axis = "Player 1";
                TopWallY = 16.5f;
                BottomWallY = -5.5f;
            } else if (_InputMethod == InputMethod.Player2)
            {
                Axis = "Player 2";
                TopWallY = 16.5f;
                BottomWallY = -5.5f;
            }

            // If player (left side) is trying to move up, do the stuff below here
            if (Input.GetAxis(Axis) > 0)
                {

                    if (CurrentTransform.position.y >= TopWallY - HalfHeight)
                    {
                        // if they are trying to go up through the top wall, stop, and skip all of this stuff
                        return;
                    }
                    else
                    {
                        // if player is NOT trying to move through the top wall, do some weird math things to make them move smoothly
                        InputDir.y = Input.GetAxis(Axis) * Speed * Mathf.Min(1, Speed / 2);

                        CurrentTransform.position += InputDir * Time.deltaTime;
                    }
                }
            // otherwise, if player is trying to move down, do this stuff instead
            if (Input.GetAxis(Axis) < 0)
                {
                    if (CurrentTransform.position.y <= BottomWallY + HalfHeight)
                    {
                        // if they are trying to go down through the bottom wall, stop, and just ignore everything else
                        return;
                    }
                    else
                    {
                        // if player 1 is NOT trying to move through the bottom wall, do some more weird math things to let them move smoothly
                        InputDir.y = Input.GetAxis(Axis) * Speed * Mathf.Min(1, Speed / 2);

                        CurrentTransform.position += InputDir * Time.deltaTime;
                    }
                }
                
        }
    }
}