using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosn;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 10f;
    void Start()
    {
        startingPosn = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) {return;} //MathF.epsilon is the smallest possible decimal number, better to compare floats to this.
        float cycles = Time.time / period; // Continually growing over time
        const float tau = Mathf.PI * 2; //Constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles*tau); // Going from -1 to 1
        movementFactor = (rawSinWave +1f)/2; //Recalculated to go from 0-1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosn + offset;
    }
}
