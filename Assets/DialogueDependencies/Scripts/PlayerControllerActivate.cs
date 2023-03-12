using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerActivate : MonoBehaviour
{
    PlayerMovement playerScript;

    void Start()
    {
      playerScript = GetComponent<PlayerMovement>();
    }
    public void ActivatePlayerController()
    {
       playerScript.enabled = true;
    }
}
