using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    private Rigidbody rigidbody1;
    private AudioSource audioSource;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip audioClip;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            RotateToLeft();
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            RotateToRight();
        }
        else
        {
            StopRotate();
        }
    }

    private void StartThrusting()
    {
        rigidbody1.AddRelativeForce(Vector3.up * Time.deltaTime * mainThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    private void StopThrusting()
    {
        mainBooster.Stop();
        audioSource.Stop();
    }

    private void RotateToRight()
    {
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
        ApplyRotation(Vector3.back);

    }

    private void RotateToLeft()
    {
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
        ApplyRotation(Vector3.forward);
    }

    private void StopRotate()
    {
        leftBooster.Stop();
        rightBooster.Stop();
    }

    private void ApplyRotation(Vector3 direction)
    {
        rigidbody1.freezeRotation = true;
        rigidbody1.transform.Rotate(direction * Time.deltaTime * rotationThrust);
        rigidbody1.freezeRotation = false;
    }

    private void OnDisable()
    {
        audioSource.Stop();
        mainBooster.Stop();
        leftBooster.Stop();
        rightBooster.Stop();
    }
}
