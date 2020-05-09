using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float speed = 15f;  // meters
    [SerializeField] float maxRange = 10f;


    // Start is called before the first frame update
    void Start()
    {
        print("start");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = (horizontalThrow * speed) * Time.deltaTime; // multiply by time-between-frames (check this by multiplying this value with the framerate)
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -maxRange, maxRange);

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = (verticalThrow * speed) * Time.deltaTime; // multiply by time-between-frames (check this by multiplying this value with the framerate)
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -maxRange/2, maxRange/2);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
