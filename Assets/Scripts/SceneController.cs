using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelOne()
    {
        Global.health = 5;
        SceneManager.LoadScene(2);
    }

    public void LevelTwo()
    {
        if (Global.levelTwoUnlocked)
        {
            Global.health = 5;
            SceneManager.LoadScene(3);
        }
    }

}
