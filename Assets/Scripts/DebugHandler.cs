using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugHandler : MonoBehaviour
{
    CollitionHandler collitionHandler;

    // Start is called before the first frame update
    void Start()
    {
        collitionHandler = GetComponent<CollitionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug.isDebugBuild)
            ProcessDebugKeys();
    }

    private void ProcessDebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }

        if (Input.GetKey(KeyCode.C))
        {
            ToggleCollitions();
        }
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

    private void ToggleCollitions()
    {
        collitionHandler.CollitionDisabled = !collitionHandler.CollitionDisabled;
    }

}
