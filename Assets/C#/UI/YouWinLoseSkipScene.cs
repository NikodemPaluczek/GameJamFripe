using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinLoseSkipScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
