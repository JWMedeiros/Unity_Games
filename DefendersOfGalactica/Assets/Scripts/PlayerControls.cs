using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float controlSpeed = 20f;
    [SerializeField] float xRange = 6f;
    [SerializeField] float yRange = 5f;

    [SerializeField] GameObject[] lasers;

    //Changing Pitch with up/down movement
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -25f;

    [SerializeField] float positionYawFactor= 3f;

    //Changing Roll with left/right Movement
    [SerializeField] float positionRollFactor = -2f;
    [SerializeField] float controlRollFactor = -10f;

    float horizontalThrow, verticalThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        float xOffset = horizontalThrow * Time.deltaTime * controlSpeed;
        float yOffset = verticalThrow * Time.deltaTime * controlSpeed;

        float newXPos = transform.localPosition.x + xOffset;
        float newYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPos, -yRange + 2, yRange + 1);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void ProcessRotation()
    {
        //X axis Rotation
        float pitch = (transform.localPosition.y * positionPitchFactor) + (verticalThrow * controlPitchFactor);
        //Y axis Rotation
        float yaw = transform.localPosition.x * positionYawFactor;
        //Z axis Rotation
        float roll = (transform.localPosition.x* positionRollFactor)+(horizontalThrow*controlRollFactor);
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    void ActivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    void DeactivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
