using UnityEngine;

public class Goblin2 : MonoBehaviour {
    public Transform target;
    public float speed = 10;
    public bool atDestination = false;
    private float elapsedTime = 0f;

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5f)
    {
        var p1 = target.position;
    var p0 = transform.position;
    transform.position = Vector3.MoveTowards(p0, p1, speed* Time.deltaTime);

    }

}

}
