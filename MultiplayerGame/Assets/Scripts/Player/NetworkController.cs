using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using SC15.Player;

public class NetworkController : NetworkBehaviour
{
    public bool auth;
    public PlayerMovement mover;
    public PlayerCam cam;
    public Sliding slide;
    void Start()
    {
        auth = isLocalPlayer;
        mover = GetComponent<PlayerMovement>();
        slide = GetComponent<Sliding>();

        if (!auth)
        {
            mover.enabled = false;
            cam.enabled = false;
            slide.enabled = false;
            cam.GetComponent<Camera>().enabled = false;
            cam.GetComponent<AudioListener>().enabled = false;
            cam.enabled = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
