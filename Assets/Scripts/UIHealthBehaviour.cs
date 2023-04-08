using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealthBehaviour : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = $"Health: {Global.health}";
    }
}
