using System.Collections.Generic;
using UnityEngine;

public class ExplosiveInputTrigger : MonoBehaviour {
    public List<Rigidbody> balldebug;
    public float exploderStrenght;
    public float radius;
    public LayerMask ballsOnly;

    //Create a GameObject list variable and assign a new GameObject list to it.
    public int starttimer;
    void Explode() {
        print("boom");
        var balls = Physics.OverlapSphere(transform.position, radius, ballsOnly);
        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        foreach (var b in balls) {
            //if (b.transform.position.z > 0)
                rigidbodies.Add(b.GetComponent<Rigidbody>());
        }
        balldebug = rigidbodies;
        foreach (var rb in rigidbodies) {
            rb.AddExplosionForce(exploderStrenght, transform.position, 35f, 0, ForceMode.Impulse);
        }
    }

    private void Start() {
        Invoke("Explode", 1);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}

/*void Start() {
//Get the Rigidbody component of each gameObject and 
//call the AddExplosionForce(60f, transform.position, 15f, 0, ForceMode.Impulse) function on them.
public int starttimer;
for (int i = 0; i <= starttimer; i++) {
if (i == starttimer) {
    foreach (var ball in balls) {
        var rb = ball.GetComponent<Rigidbody>();
        rb.AddExplosionForce(60f, transform.position, 15f, 0, ForceMode.Impulse);
    }


        //arrow.GetComponent<Rigidbody>().AddExplosionForce(60f, transform.position, 15f, 0, ForceMode.Impulse);


    }


}
}
}
*/
