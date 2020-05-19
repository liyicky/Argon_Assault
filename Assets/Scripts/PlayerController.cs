using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float speed = 15f;  // meters
    [SerializeField] float maxXRange = 10f;
    [SerializeField] float maxYRange = 10f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float horizontalThrow;
    float verticalThrow;

    bool stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        print("start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
            verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void ProcessTranslation()
	{
        
        float xOffset = (horizontalThrow * speed) * Time.deltaTime; // multiply by time-between-frames (check this by multiplying this value with the framerate)
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -maxXRange, maxXRange);

        
        float yOffset = (verticalThrow * speed) * Time.deltaTime; // multiply by time-between-frames (check this by multiplying this value with the framerate)
        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -maxYRange / 2, maxYRange / 2);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
	{
        
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

    void Stop()
    {
        print("stopped");
        stopped = true;
    }
}
