using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong3D {
    public class Ball : MonoBehaviour {

        public GameManager GM;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        float HitFactor(Vector3 BallPos, Vector3 PlayerPos, float PlayerHeight)
        {
            return (BallPos.y - PlayerPos.y) / PlayerHeight;
        }

        private void OnCollisionEnter(Collision col)
        {
            // Make things harder each bounce
            GM.BallSpeed++;

            // Collision stuff, dont try to understand it, no one does
            if (col.gameObject.name == "Player 2")
            {
                float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

                Vector3 dir = new Vector3(0, y, 1).normalized;

                GetComponent<Rigidbody>().velocity = dir * GM.BallSpeed;
            }
            if (col.gameObject.name == "Player 1")
            {
                float y = HitFactor(transform.position, col.transform.position, col.collider.bounds.extents.y);

                Vector3 dir = new Vector3(0, y, -1).normalized;

                GetComponent<Rigidbody>().velocity = dir * GM.BallSpeed;
            }
            

            // Scoring
            if (col.gameObject.name == "Player 2 Goal")
            {
                GM.Player1Goal();
            }
            if (col.gameObject.name == "Player 1 Goal")
            {
                GM.Player2Goal();
            }

        }
    }
}