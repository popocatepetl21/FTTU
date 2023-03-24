using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathManager : MonoBehaviour
{
    
     public int deaths = 0;
 
     public Text deathText;
 
     public void IncreaseDeaths()

     {
          deaths++;
          PlayerPrefs.SetInt("deaths", deaths);
     }
     private void Awake() 
     {
          deaths = PlayerPrefs.GetInt("deaths");
          deathText.text = deaths.ToString();
     }

}