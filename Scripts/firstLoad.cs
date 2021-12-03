using UnityEngine;
using UnityEngine.SceneManagement;

public class firstLoad : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Additive);
    }
}
