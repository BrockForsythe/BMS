using UnityEngine;

public class gamePhaseObjects : MonoBehaviour
{
    //preexisting game objects to spawn for phase
    public GameObject ArmBackBlock;
    public GameObject PointingBlock;
    public GameObject SteppingBlock;
    public GameObject ThrowingBlock;

    //tracks the gamephase
    private int gamePhase;

    void Start()
    {
        GamePhaseOne();
        gamePhase = 1;
    }

    public void NextPhase()
    {
        //destroys current gamephase object
        Destroy(GameObject.FindWithTag("Game Phase Object"));
        Debug.Log("In Next Phase");
        //increments gamephase
        if (gamePhase < 4)
        {
            gamePhase++;
        }
        else
        {
            gamePhase = 1;
        }

        //spawns based on gamephase
        switch (gamePhase)
        {
            case 1:
                GamePhaseOne();
                break;
            case 2:
                GamePhaseTwo();
                break;
            case 3:
                GamePhaseThree();
                break;
            case 4:
                GamePhaseFour();
                break;
        }
    }

    private void GamePhaseOne()
    {
        Instantiate(ArmBackBlock, new Vector3(.5f, .8f, 0f), Quaternion.identity);
    }

    private void GamePhaseTwo()
    {
        Instantiate(PointingBlock, new Vector3(0f, 0f, 1f), Quaternion.identity);
    }

    private void GamePhaseThree()
    {
        Instantiate(SteppingBlock, new Vector3(0f, -0.3f, 0.5f), Quaternion.identity);
    }

    private void GamePhaseFour()
    {
        Instantiate(ThrowingBlock, new Vector3(0f, 0f, 4f), Quaternion.identity);
    }
}
