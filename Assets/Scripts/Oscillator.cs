using UnityEngine;

public class Oscillator : MonoBehaviour
{

    const float TAU = Mathf.PI * 2;
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Min(0.0001f)] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var cyles = Time.time / period;
        var rawSinWave = Mathf.Sin(cyles * TAU);
        var movementFactor = (rawSinWave + 1f) / 2f;
        var offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
