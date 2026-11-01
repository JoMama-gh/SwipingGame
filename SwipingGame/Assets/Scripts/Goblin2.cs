using UnityEngine;

public class Goblin2 : MonoBehaviour {
    public Transform target;
    public float speed=3;
    public bool atDestination = false;
    void Update() {
        var p1 = target.position;
        var p0 = transform.position;
        transform.position = Vector3.MoveTowards(p0, p1, speed * Time.deltaTime);
    }
}
