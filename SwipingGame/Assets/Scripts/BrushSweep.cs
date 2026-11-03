using UnityEngine;
using UnityEngine.InputSystem;

public class BrushSweeper : MonoBehaviour {
    [Header("Sweeping Settings")]
    public float sweepDistance = 1f;
    public float sweepSpeed = 5f;
    public bool useLocalAxis = true;

    private Vector3 startPosition;
    private float sweepTimer = 0f;
    public AudioSource audioSource;

    void Start() {
        startPosition = useLocalAxis ? transform.localPosition : transform.position;
        audioSource = GetComponent<AudioSource>();
    }


    void Update() {

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) {
            audioSource.Play();
        }

        if (Mouse.current != null && Mouse.current.leftButton.isPressed) {

            Sweep();

        } else {

            ResetPosition();

        }
    }

    void Sweep() {

        sweepTimer += Time.deltaTime * sweepSpeed;
        float offset = Mathf.Sin(sweepTimer) * sweepDistance;

        if (useLocalAxis) {
            transform.localPosition = startPosition + new Vector3(0, 0, offset);
        } else {
            transform.position = startPosition + new Vector3(0, 0, offset);
        }
    }

    void ResetPosition() {
        sweepTimer = 0f;

        if (useLocalAxis) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPosition, Time.deltaTime * sweepSpeed);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime * sweepSpeed);
        }
    }
}