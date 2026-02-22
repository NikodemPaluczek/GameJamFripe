using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgamePortal : MonoBehaviour
{
    Player player;

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();
        if (player != null)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
