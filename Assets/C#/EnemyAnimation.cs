using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.Play("attack");
        }
        else
        {
            anim.Play("walk");
        }
    }
}