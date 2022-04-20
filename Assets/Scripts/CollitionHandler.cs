using UnityEngine;

public class CollitionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            case "Finish":
                Debug.Log("You win! :)");
                break;
            default:
                Debug.Log("You must be dead now :( " + other.gameObject.name);
                break;
        }
    }
}
