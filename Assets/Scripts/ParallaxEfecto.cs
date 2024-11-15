using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfecto : MonoBehaviour
{


    private float lenght, startpos;
    public GameObject camera;
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallax));

        float dist = (camera.transform.position.x * parallax);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lenght) startpos += lenght;
        else if  (temp < startpos - lenght ) startpos -= lenght;
    }
}
