using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseContinue : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject continueButton;
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        continueButton.SetActive(true);
    }

    // Update is called once per frame
    public void Continue()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        continueButton.SetActive(false);
    }
}
