using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class sceneLoader : MonoBehaviour
{
    private static string currentscene;
    private static string targetscene;
    private static bool loadlevel;


    private void Start()
    {
        //default added scene is the lobby
        currentscene = "Lobby";
        loadlevel = false;
    }

    void Update()
    {
        if (loadlevel)
        {
            loadlevel = false;
            StartCoroutine(WaitUntilLoaded());
        }
    }

    public void NewScene(string ts)
    {
        targetscene = ts;
        loadlevel = true;
    }

    private IEnumerator WaitUntilLoaded()
    {
        //tracks the loading operation
        AsyncOperation op = SceneManager.LoadSceneAsync(targetscene, LoadSceneMode.Additive);
        //op.allowSceneActivation = false;

        //while its loding continues to load
        while (!op.isDone)
        {
            yield return null;
        }

        //once finished, sets the active scene to be the new and allows scene to spawn
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetscene));
        //op.allowSceneActivation = true;

        //unloads current scene and sets it to be the new one
        SceneManager.UnloadSceneAsync(currentscene);
        currentscene = targetscene;
    }

    //easy to menu call
    public void ToLobby()
    {
        NewScene("Lobby");
    }

    //quits application
    public void ExitApplication()
    {
        Application.Quit();
    }
}
