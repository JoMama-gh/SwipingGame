using UnityEngine;

public class MultiTargetMovement : MonoBehaviour {

    public Transform[] targetPositions;
    public float speed = 5f;


    public float closeEnoughDistance = 0.5f;

    private int currentTargetIndex = 0;

    void Update() {
        if (targetPositions != null && targetPositions.Length > 0) {
            Transform currentTarget = targetPositions[currentTargetIndex];

            if (currentTarget != null) {
                float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
                if (distanceToTarget < closeEnoughDistance) {
                    currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
                    return;
                }

                Vector3 direction = (currentTarget.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                if (direction != Vector3.zero) {
                    transform.forward = new Vector3(direction.x, 0, direction.z);
                }
            }
        }
    }
}
