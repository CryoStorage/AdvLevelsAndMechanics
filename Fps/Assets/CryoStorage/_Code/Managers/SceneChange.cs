using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SceneFromString(string sceneName)
   {
       SceneManager.LoadScene(sceneName);
        Debug.Log("loading from string");
   }

    public void SceneFromIndex(int index)
    {
        SceneManager.LoadScene(index);
        Debug.Log("loading from index");
    }
}
