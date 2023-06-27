using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SC15.Player
{
    public class PlayerCam : MonoBehaviour
    {
        public float sensX;
        public float sensY;

        public Transform playerBody;

        float xRot = 0, yRot = 0;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRot += mouseX;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            //rotate camera and orientation
            transform.rotation = Quaternion.Euler(xRot, yRot, 0);
            playerBody.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }
}
