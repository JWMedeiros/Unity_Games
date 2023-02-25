using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down")] [SerializeField] float controlSpeed = 20f;
    [Tooltip("How much the ship can move left and right")] [SerializeField] float xRange = 6f;
    [Tooltip("How much the ship can move up and down")] [SerializeField] float yRange = 5f;
    
    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")] [SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor= 5f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -25f;
    [SerializeField] float controlRollFactor = -40f;

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
        float roll = (transform.localPosition.x)+(horizontalThrow*controlRollFactor);
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
           SetLasers(true);
        }
        else
        {
            SetLasers(false);
        }
    }
    void SetLasers(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
