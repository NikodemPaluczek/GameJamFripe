using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private int heathPoints = 2;

    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform[] patrolpoints;
    private Transform currentDestination;
    private float minDistance = 1f;

    private bool isUnderAttack = false;

    private NavMeshAgent agent;
    private float distance;

    [SerializeField] private float enemySeeingRange = 5f;

    public IEnumerator OrangeAttack()
    {
        Debug.Log("korutyna sie odpala");
        isUnderAttack = true;
        heathPoints--;
        if (heathPoints == 0)
        {
            this.gameObject.SetActive(false);
            yield break;
        }
        agent.isStopped = true;
        yield return new WaitForSeconds(2f);
        isUnderAttack = false;
        agent.isStopped = false;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentDestination = patrolpoints[Random.Range(0, patrolpoints.Length)];
    }

    private void Update()
    {   if (!isUnderAttack)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, enemySeeingRange))
            {
                if (hit.collider.GetComponent<Player>() != null)
                {
                    currentDestination = playerPosition;
                }
            }
            distance = Vector3.Distance(agent.transform.position, currentDestination.position);
            if (distance < minDistance)
            {
                if (currentDestination == playerPosition)
                {
                    agent.isStopped = true;
                }
                else
                {
                    currentDestination = patrolpoints[Random.Range(0, patrolpoints.Length)];
                }
            }
            else
            {
                agent.isStopped = false;
                agent.destination = currentDestination.position;
            }
        }
    }
}