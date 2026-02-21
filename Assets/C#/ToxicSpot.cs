using System.Collections;
using UnityEngine;

public class ToxicSpot : MonoBehaviour
{
    
    Player player;
    private Coroutine damageCoroutine;

    private void OnTriggerEnter(Collider other)
    {

        player = other.GetComponent<Player>();
        if(player != null)
        {
            damageCoroutine = StartCoroutine(DecreaseHpOverTime());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponent<Player>();
        if (player != null)
        {
            StopCoroutine(damageCoroutine);
        }
    }

    IEnumerator DecreaseHpOverTime()
    {
        while (true)
        {
            player.UpdateHealth(-1);
            yield return new WaitForSeconds(2);
        }
    }

}
