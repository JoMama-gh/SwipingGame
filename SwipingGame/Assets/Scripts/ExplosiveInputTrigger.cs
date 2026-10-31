using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ExplosiveInputTrigger : MonoBehaviour {
    public List<GameObject> Ball = new List<GameObject>();
    //Create a GameObject list variable and assign a new GameObject list to it.


    public void OnTriggerEnter(Collider collider) {
        //Get the Gameobject of the collider (collider.gameObject).
        var ball = collider.gameObject;
        //Add it to the list.
        //balls.Add(ball);
    }

}

/*void Start() {
//When the space bar is pressed, go through the list with a foreach-loop.
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
