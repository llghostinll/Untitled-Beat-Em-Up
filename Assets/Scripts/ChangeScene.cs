 using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScenes : MonoBehaviour
{
    public void MovingScene(int sceneNumber)
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }
}
