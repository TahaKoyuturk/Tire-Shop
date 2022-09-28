using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    public void WinContinue()
    {
        SceneManager.LoadScene("Level2");
    }
}
