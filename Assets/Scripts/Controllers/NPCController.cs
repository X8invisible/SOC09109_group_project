using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public Transform target;

    // This is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget < 1000)
        {
          Vector3 targetDirection = target.position - transform.position;
          float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
          Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

          transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
          transform.Translate(Vector3.up * Time.deltaTime * 2);
        }
    }
}
