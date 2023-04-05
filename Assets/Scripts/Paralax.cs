using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length, startPosition;
    public GameObject Camera;
    public float paralaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (Camera.transform.position.x * paralaxEffect);
        float reset = Camera.transform.position.x * (1 - paralaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        if(reset > startPosition + length)
        {
            startPosition += length;
        }
        else if(reset < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
