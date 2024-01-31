using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Transform target;

    private void Update()
    {
        //Get the target
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
            MoveTowardsTarget();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}