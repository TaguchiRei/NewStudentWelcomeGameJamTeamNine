using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void OnstartButton()
    {
        SceneManager.LoadScene("InGame");
    }
}
