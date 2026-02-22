using UnityEngine;

public class OrangeTeleports : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;
    Player player;


    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();
        if (player != null)
        {
            if (ProgressionManager.Instance.orangeNeonsCounter > 0)
            {
                ProgressionManager.Instance.updateOrangeCounter(-1);
                Player.InstanceNavMesh.Warp(teleportPoint.position);
            }
        }
    }
}
