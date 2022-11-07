using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text spreadText;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
