 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ChangeScenes : MonoBehaviour
{
       public void MoveToSceneTwo()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
