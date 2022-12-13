using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Move")]
    public float runningSpeed;
    public float xSpeed;
    public float limitX;
    public bool isRunning;
    [Header("PlayerHorizontalMove")]
    public float newX = 0;
    float _touchXDelta = 0;
    
    
    public Animator playerAnimControl;
    public GameManager gameManager;

    void Update()
    {
        SwipeCheck();
        IsRunning();
    }
    void IsRunning()
    {
        if (gameManager.startGame)
        {
            if (runningSpeed > 0.1f && !isRunning)
            {
                playerAnimControl.CrossFade("FastRun",0.10f);
                isRunning = true;
            }
            else if (isRunning && runningSpeed <= 0.1)
            {
                isRunning = false;
            }
        }
    }
    void SwipeCheck()
    {
         if (gameManager.startGame) 
         {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
            }
            else if (Input.GetMouseButton(0))
            {
                _touchXDelta = Input.GetAxis("Mouse X");
            }

            newX = transform.position.x + xSpeed * _touchXDelta * Time.deltaTime;
            newX = Mathf.Clamp(newX, -limitX, limitX);
            Vector3 newPosition = new Vector3(newX, transform.position.y,
                transform.position.z + runningSpeed * Time.deltaTime);
            transform.position = newPosition;
         }
    }
}
