using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScriptUI : MonoBehaviour
{
    public float PlayersHealth;
    public Text healthtext;
    public GameObject playerObj;

    void Update()
    {
        PlayersHealth = playerObj.GetComponent<Damage>().health;
        healthtext.text = "" + PlayersHealth;
    }
}