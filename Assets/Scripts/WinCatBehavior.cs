using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCatBehavior : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(4);
            Global.levelTwoUnlocked = true;
        }
    }
}
