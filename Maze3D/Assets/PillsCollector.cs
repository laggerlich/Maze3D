using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PillsCollector : MonoBehaviour
{
    private int counter = 0;
    public TextMeshProUGUI counterText;
    public int purpose = 18;
    void Start()
    {
        gameObject.tag = "Player";
        counterText.text = $"Pills: 0";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUpPills")
        {
            //Debug.Log("Triggered");
            other.gameObject.SetActive(false);
            counter++;
            counterText.text = $"Pills: {counter}";
        }
        else if(other.tag == "FinishPill")
        {
            if(counter >= purpose)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}