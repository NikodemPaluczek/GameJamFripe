using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] ToxicSpot toxicSpot;

    private int heathPoints = 2;

    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform[] patrolpoints;
    private Transform currentDestination;
    private float minDistance = 1f;

    private bool isUnderAttack = false;

    private NavMeshAgent agent;
    private float distance;

    private Vector3 pushBackDir;
    [SerializeField] private float explosionForce = 3f;

    [SerializeField] private float enemySeeingRange = 15f;

    public void EnemyDeath()
    {
        Instantiate(toxicSpot, transform.position, Quaternion.Euler(-90, 0,0));
        this.gameObject.SetActive(false);
    }

    public IEnumerator OrangeAttack()
    {
        Debug.Log("korutyna sie odpala");
        isUnderAttack = true;
        heathPoints--;
        if (heathPoints == 0)
        {
            EnemyDeath();
            yield break;
        }
        agent.isStopped = true;
        yield return new WaitForSeconds(5f);
        isUnderAttack = false;
        agent.isStopped = false;
    }
    public IEnumerator GreenAttack()
    {
        Debug.Log("korutyna sie odpala");
        isUnderAttack = true;
        heathPoints--;
        Player.Instance.UpdateHealth(1);
        
        if (heathPoints == 0)
        {
            EnemyDeath();
            yield break;
        }
        agent.isStopped = true;
        yield return new WaitForSeconds(3f);
        isUnderAttack = false;
        agent.isStopped = false;
    }
    public IEnumerator PinkAttack()
    {
        Debug.Log("korutyna sie odpala");
        isUnderAttack = true;
        heathPoints--;
        if (heathPoints == 0)
        {
            EnemyDeath();
            yield break;
        }

        agent.isStopped = true;

        pushBackDir = transform.position - playerPosition.position;

        transform.position += pushBackDir * explosionForce;
        playerPosition.position -= pushBackDir * explosionForce;
        yield return new WaitForSeconds(15f);
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
                    StartCoroutine(TryToAttack());
                    
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

    private IEnumerator TryToAttack()
    {
        isUnderAttack = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(0.25f);

        if (distance < minDistance)
        {
            Player.Instance.UpdateHealth(-1);

        }
        agent.isStopped = false;
        isUnderAttack = false;
    }
}