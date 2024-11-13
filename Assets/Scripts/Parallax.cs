using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallax_m;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    private float spriteWidth, startPosition;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * parallax_m;
        float moveAmount = cameraTransform.position.x * (1 - parallax_m);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;


        if (moveAmount > startPosition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;

        }

        else if (moveAmount < startPosition - spriteWidth)
        {

            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;

        }

    }
}
