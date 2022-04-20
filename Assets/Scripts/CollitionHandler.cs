using UnityEngine;
using UnityEngine.SceneManagement;

public class CollitionHandler : MonoBehaviour
{
    private Movement movement;
    private AudioSource audioSource;
    [SerializeField] float reloadDelay = 2f;
    [SerializeField] float nextLevelDelay = 2f;
    [SerializeField] AudioClip destroyClip;
    [SerializeField] AudioClip successClip;
    bool inTransition = false;

    private void Start()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (inTransition) return;

        switch (other.gameObject.tag)
        {
            case "Friendly":
                OnFriendly();
                break;
            case "Finish":
                OnFinish();
                break;
            default:
                OnCrash();
                break;
        }
    }

    private void OnFinish()
    {
        movement.enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successClip);
        inTransition = true;
        Invoke("LoadNextLevel", nextLevelDelay);
    }

    private void OnFriendly()
    {
        Debug.Log("This is friendly");
    }

    private void OnCrash()
    {
        movement.enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(destroyClip);
        inTransition = true;
        Invoke("ReloadScene", reloadDelay);
    }

    private void LoadNextLevel()
    {
        var currentScene = SceneManager.GetActiveScene();
        var nextSceneIndex = currentScene.buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings == nextSceneIndex)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
