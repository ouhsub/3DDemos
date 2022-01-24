using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour
{
    GameObject endUI;
    private void Start()
    {
        endUI = GameObject.Find("EndUI");
        endUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Finished!!!");
            Time.timeScale = 0;
            endUI.SetActive(true);
        }
    }
}
