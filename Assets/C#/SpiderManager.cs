using UnityEngine;

public class SpiderManager : MonoBehaviour
{
    [SerializeField] Transform[] points;
    private Transform currentPoint;
    private Transform lastPoint;
    private Vector3 direction;

    private void Update()
    {
        if (direction == Vector3.zero)
        {
            if (currentPoint != null)
            {
                lastPoint = currentPoint;
            }
            currentPoint = pointA;
        }
        do
        {
            direction = currentPoint.position - transform.position;
            direction = direction.normalized;
            transform.position += direction * Time.deltaTime;
        } while (direction != Vector3.zero);
        
       
    }
}
