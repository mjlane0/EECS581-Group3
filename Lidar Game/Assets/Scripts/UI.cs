using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int lives = 3;
    public Text spreadText;
    public GameObject gameOver;
    public GameObject gun;
    public GameObject player;
    public Text gameOverText;
    public Image fadeImage;
    public Text liveNum;

    private float fadeInDuration = 1.0f;
    private float fadeOutDuration = 2.0f;
    private float currentTime = 0.0f;
    bool dead;
    public bool go; //game over

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TriggerGameOver();
        liveNum.text = "Lives: " + lives.ToString();
        GracePeriod();
        CheckSpread();
    }

    void CheckSpread()
    {
        if(gun.GetComponent<RayCast>().highSpread == gun.GetComponent<RayCast>().Spread)
            spreadText.text = "Current Spread: Wide";
        else if(gun.GetComponent<RayCast>().medSpread == gun.GetComponent<RayCast>().Spread)
            spreadText.text = "Current Spread: Medium";
        else if(gun.GetComponent<RayCast>().lowSpread == gun.GetComponent<RayCast>().Spread)
            spreadText.text = "Current Spread: Narrow";
        else
            spreadText.text = "Current Spread: Unknown";
    }

    public void TriggerGameOver()
    {
            if(go == true)
            {
            gameOver.SetActive(true);
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, currentTime / fadeOutDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);

            float textAlpha = Mathf.Lerp(0, 1, currentTime / fadeInDuration);
            gameOverText.color = new Color(224, 35, 35, textAlpha);

            if (currentTime >= fadeOutDuration)
            {
                    SceneManager.LoadScene("MainMenu");
            }
        }
    }
    void GracePeriod()
    {
        //if (dead) //dead just means an enemy touches us
        //{
            if(!go && dead)
            {
                lives--;
                if(lives > 0)
                {
                    player.transform.position = player.GetComponent<PlayerMovement>().startPos;
                    //yield return new WaitForSeconds(.5f);
                    player.GetComponent<PlayerMovement>().dead = false;
                    go = false;
                    //yield return new WaitForSeconds(.5f);
                    
                }
                else
                {
                    go = true;
                }
            }
        //}
        dead = player.GetComponent<PlayerMovement>().dead;
    }
}
