using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level2ButtonBehaviour : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (Global.levelTwoUnlocked)
        {
            text.text = "Level 2";
        }
        else
        {
            text.text = "LOCKED";
        }
    }

}
