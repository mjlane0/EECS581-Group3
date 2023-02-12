using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject colorMenu;
    public GameObject levelMenu;
    public bool paused = false;

    public GameObject ul;
    public GameObject ur;
    public GameObject dr;
    public GameObject dl;
    int presses;

    // Start is called before the first frame update
    void Start()
    {
        ul.SetActive(true);
        ur.SetActive(false);
        dr.SetActive(false);
        dl.SetActive(false);
        colorMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == true)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        colorMenu.SetActive(false);
        levelMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ColorPick()
    {
        colorMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void LevelPick()
    {
        levelMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void BackToPause()
    {
        colorMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void AdjustUI()
    {
        presses++;
        //Fetch the Text Component
			int pFinal = presses % 4;
			switch(pFinal)
			{
				case 0:
				{            
                    
                    //Switch the Text alignment to the middle
                    ul.SetActive(true);
                    ur.SetActive(false);
                    dr.SetActive(false);
                    dl.SetActive(false);
					break;
				}
				case 1:
				{
					ul.SetActive(false);
                    ur.SetActive(true);
                    dr.SetActive(false);
                    dl.SetActive(false);		
					break;
				}
				case 2:
				{
					ul.SetActive(false);
                    ur.SetActive(false);
                    dr.SetActive(true);
                    dl.SetActive(false);		
					break;
				}
                case 3:
				{
					ul.SetActive(false);
                    ur.SetActive(false);
                    dr.SetActive(false);
                    dl.SetActive(true);		
					break;
				}
				default:
					break;
			}
    }

}
