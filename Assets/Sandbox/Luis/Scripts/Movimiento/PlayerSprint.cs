using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    PlayerMovement mv;
    float stamina = 5, maxStamina = 5;
    float WalkSpeed, sprintSpeed;
    bool isRunning;

    Rect staminaRect;
    Texture2D staminaTexture;
    void Start()
    {
        mv = (PlayerMovement)GetComponent<PlayerMovement>();
        WalkSpeed = mv.speed;
        sprintSpeed = WalkSpeed * 2;

        staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 50);
        staminaTexture = new Texture2D(1, 1);
        staminaTexture.SetPixel(0, 0, Color.red);
        staminaTexture.Apply();
    }

    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        mv.speed = isRunning ? sprintSpeed : WalkSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetRunning(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetRunning(false);
        }

        if (stamina < 0)
        {
            stamina = 0;
            SetRunning(false);
        }
        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina<0)
            {
                stamina = 0;
                SetRunning(false);
            }
        }
        else if (stamina< maxStamina)
        {
            stamina += Time.deltaTime;
        }
    }
    void OnGUI()
    {
        float ratio = stamina / maxStamina;
        float rectWidth = ratio * Screen.width / 3;
        staminaRect.width = rectWidth;
        GUI.DrawTexture(staminaRect, staminaTexture);
    }
}
