using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene currentScene;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region ButtonFunctions

    #region Menu Buttons
    //Buttons specific to the menu scene
    //Functions redirect you to correct location within project
    public void RopeChallenge()
    {
        SceneManager.LoadScene(sceneName = "RopeChallenge");
    }

    public void FitnessChallenge()
    {
        SceneManager.LoadScene(sceneName = "FitnessChallenge");
    }

    public void CubeChallenge()
    {
        SceneManager.LoadScene(sceneName = "CubeChallenge");
    }

    #endregion

    #region ReturnToMenu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(sceneName = "Menu");
    }
    #endregion
    #endregion
}
