using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SC15.Player
{
    public class Sliding : MonoBehaviour
    {
        [Header("References")]
        public Transform playerBody;
        private Rigidbody rb;
        private PlayerMovement pm;

        [Header("Sliding")]
        public float maxSlideTime;
        public float slideForce;
        private float slideTimer;

        public float slideYScale;
        private float startYscale;

        [Header("Input")]
        public KeyCode slideKey = KeyCode.LeftControl;
        private float hInput;
        private float vInput;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            pm = GetComponent<PlayerMovement>();

            startYscale = playerBody.localScale.y;
        }

        private void Update()
        {
            hInput = Input.GetAxisRaw("Horizontal");
            vInput = Input.GetAxisRaw("Vertical");

            if (Input.GetKeyDown(slideKey) && (hInput != 0 || vInput != 0))
                StartSlide();

            if (Input.GetKeyUp(slideKey) && pm.sliding)
                StopSlide();
        }

        private void FixedUpdate()
        {
            if (pm.sliding)
                SlidingMovement();
        }

        private void StartSlide()
        {
            pm.sliding = true;

            playerBody.localScale = new Vector3(playerBody.localScale.x, slideYScale, playerBody.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            slideTimer = maxSlideTime;
        }
        private void SlidingMovement()
        {
            Vector3 inputDir = playerBody.forward * vInput + playerBody.right * hInput;

            //sliding normal
            if (!pm.OnSlope() || rb.velocity.y > -0.1f)
            {
                rb.AddForce(inputDir.normalized * slideForce, ForceMode.Force);

                slideTimer -= Time.deltaTime;
            }
            //sliding down a slope
            else
            {
                rb.AddForce(pm.GetSlopeMoveDirection(inputDir) * slideForce, ForceMode.Force);
            }

            if (slideTimer <= 0)
                StopSlide();
        }
        private void StopSlide()
        {
            pm.sliding = false;
            playerBody.localScale = new Vector3(playerBody.localScale.x, startYscale, playerBody.localScale.z);
        }

    }
}
