using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Is_ball_inside : MonoBehaviour {
    public List<GameObject> balls = new List<GameObject>();
    public void OnTriggerEnter(Collider collider) {
        var gameobject = collider.GetComponent<GameObject>();
        var ball = collider.gameObject;
        balls.Add(ball);

    }

    public void OnTriggerExit(Collider collider) {
        var gameobject = collider.GetComponent<GameObject>();


    }
}
