using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong3D
{
    public class GameManager : MonoBehaviour
    {

        // Sanity check
        private bool GameStarted = false;
        private bool newRound = false;

        // Scoring
        public int ScoreR;
        public int ScoreL;

        // HUD Updating
        public Text ScoreRText;
        public Text ScoreLText;

        // Ball
        public GameObject Ball;
        public Rigidbody BallRB;
        public float BallSpeed;
        public float InitialBallSpeed;

        // Use this for initialization
        void Start()
        {
            InitialBallSpeed = BallSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            // Check if the start button is hit
            if( Input.GetAxis("Start") > 0 )
            {
                // If it is, check to make sure the game isnt already started
                if (GameStarted == true)
                {
                    if (newRound)
                    {
                        BallStart();
                    }
                    else
                    {
                        return;
                    }
                }else
                {
                    StartGame();
                }
            }

            ScoreHUDUpdate();
        }


        // This Starts the game
        public void StartGame()
        {
            /*
            // Debug Stuff
            print("Starting Game");
            // No more debug stuff
            */
            GameStarted = true;
            ScoreL = 0;
            ScoreR = 0;
            BallStart();
        }

        public void ScoreHUDUpdate()
        {
            ScoreLText.text = ScoreL.ToString();
            ScoreRText.text = ScoreR.ToString();
        }

        public void BallStart()
        {
            BallRB.velocity = new Vector3(0, 1.5f, 1) * BallSpeed;
            newRound = false;
        }

        public void Player1Goal()
        {
            BallRB.velocity = Vector3.zero;
            BallSpeed = InitialBallSpeed;
            ScoreR++;
            Ball.transform.position = new Vector3(0, 4, 0);
            newRound = true;
        }
        public void Player2Goal()
        {
            BallRB.velocity = Vector3.zero;
            BallSpeed = InitialBallSpeed;
            ScoreL++;
            Ball.transform.position = new Vector3(0, 4, 0);
            newRound = true;
        }
    }
}