using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menulock : MonoBehaviour
{
    public GameObject menuPaused;
    
    [SerializeField] KeyCode keyMenuPaused;
    bool isMenuPaused = false;
    private void Start()
    {
        menuPaused.SetActive(false);
    }

    private void Update()
    {
        ActiveMenu();
    }
    void ActiveMenu()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }

        if (isMenuPaused)
        {
            menuPaused.SetActive(true);
            
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            menuPaused.SetActive(false);
           
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void MunePausedContinue()
    {
        isMenuPaused = false;
    }

    public void MunePausedSettings()
    {
        Debug.Log("Настройки");
    }

    public void MunePausedMainMenu()
    {
        Debug.Log("Главное меню");
    }
}
