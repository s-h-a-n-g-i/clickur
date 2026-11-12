using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameClick() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
