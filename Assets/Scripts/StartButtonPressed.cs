using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonPressed : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}
