using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
       switch(other.gameObject.tag)
        {
            case "start":
                break;
            case "finish":
                LoadNextLevel();
                break;
            case "fuel":
                break;
            default:
                ReloadLLevel();
                break;


        }
    }

    private void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel=currentIndex+1;
        if(nextLevel==SceneManager.sceneCountInBuildSettings)
        {
            nextLevel = 0;
        }
        SceneManager.LoadScene(nextLevel);
        
    }

    void ReloadLLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
