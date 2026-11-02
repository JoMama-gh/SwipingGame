using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class ShapeFillFunctionality : MonoBehaviour
{
    // Player side Raycast box.
    [SerializeField] Vector2 pRaycastBox;
    // Player side Raycast box transform position.
    private Vector3 pRaycastBoxPosition;
    // Mirror side Raycast box.
    [SerializeField] Vector2 mRaycastBox;
    // Mirror side Raycast box transform position.
    private Vector3 mRaycastBoxPosition;
    // Ball prefab size X being min and Y being max.
    [SerializeField] Vector2 ballSize;
    // Ball prefab.
    [SerializeField] GameObject ballPrefab;
    // Space between balls.
    [SerializeField] float ballSpace;
    // Ball position randomization
    [SerializeField] float randomize;
    // Colliders layermask
    [SerializeField] LayerMask collidersMask;
    // The balls amount.
    [SerializeField] int ballAmount;

    // Function to go through all the ball instance points on players side
    // in for loop.
    List<Vector3> PointOnPlayersSide()
    {
        // Set player side raycast box transfrom position.
        pRaycastBoxPosition = new Vector3(transform.position.x, transform.position.y, 2.5f);

        // Player raycast boxes float values changed into integers
        // and space between them applied.
        Vector2Int pointsCount = Vector2Int.FloorToInt(pRaycastBox / ballSpace);
        // List of our all points
        var points = new List<Vector3>();
        // For loop to go through all points in X -axis.
        for(int i = 0; i < pointsCount.x; ++i)
        {
            // For loop to go through all points in Y -axis.
            for(int j = 0; j < pointsCount.y; ++j)
            {
                // Player Raycast box starting position.
                var p0 = pRaycastBoxPosition;
                // Center the player raycast box starting position
                // to the left.
                p0.x -= pRaycastBox.x / 2;
                // Center the player raycast box starting position
                // to the back.
                p0.z -= pRaycastBox.y / 2;
                // A single point inside player raycast box with
                // added randomization for position change to the
                // right and forward.
                var p = p0 +
                    (i * ballSpace + Random.Range(-1, 1) * randomize) * Vector3.right +
                    (j * ballSpace + Random.Range(-1, 1) * randomize) * Vector3.forward;

                // A sphere calculation that is our point inside a collider.
                // If our point is inside a collider then add the point to the
                // Vector3 list
                var hits = Physics.OverlapSphere(p, 0.1f, collidersMask);
                if(hits.Length > 0)
                {
                    points.Add(p);
                }

            }
        }

        return points;
    }

    // Function to go through all the ball instance points on mirrors side
    // in for loop.
    List<Vector3> PointOnMirrorsSide()
    {
        // Set mirror side raycast box transfrom position.
        mRaycastBoxPosition = new Vector3(transform.position.x, transform.position.y, -2.5f);

        // Mirror raycast boxes float values changed into integers
        // and space between them applied.
        Vector2Int pointsCount = Vector2Int.FloorToInt(mRaycastBox / ballSpace);
        // List of our all points
        var points = new List<Vector3>();
        // For loop to go through all points in X -axis.
        for (int i = 0; i < pointsCount.x; ++i)
        {
            // For loop to go through all points in Y -axis.
            for (int j = 0; j < pointsCount.y; ++j)
            {
                // Mirror Raycast box starting position.
                var p0 = mRaycastBoxPosition;
                // Center the mirror raycast box starting position
                // to the left.
                p0.x -= mRaycastBox.x / 2;
                // Center the mirror raycast box starting position
                // to the back.
                p0.z -= mRaycastBox.y / 2;
                // A single point inside mirror raycast box with
                // added randomization for position change to the
                // right and forward.
                var p = p0 +
                    (i * ballSpace + Random.Range(-1, 1) * randomize) * Vector3.right +
                    (j * ballSpace + Random.Range(-1, 1) * randomize) * Vector3.forward;

                // A sphere calculation that is our point inside a collider.
                // If our point is inside a collider then add the point to the
                // Vector3 list
                var hits = Physics.OverlapSphere(p, 0.1f, collidersMask);
                if (hits.Length > 0)
                {
                    points.Add(p);
                }

            }
        }

        return points;
    }

    // Function to Instantiate Player side balls
    void PlayerInstantiateAtRandom(List<Vector3> points, int ballAmount)
    {


        while (ballAmount > 0)
        {
            int index = Random.Range(0, points.Count);
            float randomizeSize = Random.Range(ballSize.x, ballSize.y);
            var point = points[index];
            GameObject ball = Instantiate(ballPrefab, point, Quaternion.identity);
            ball.transform.localScale = new Vector3(1, 1, 1) * randomizeSize;
            points.RemoveAt(index);
            ballAmount--;
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var pPoints = PointOnPlayersSide();
        var mPoints = PointOnMirrorsSide();
        PlayerInstantiateAtRandom(pPoints, ballAmount);
    }

    // Gizmo's function to represent our boxes
    private void OnDrawGizmos()
    {
        // Draw player side Raycast box.
        Gizmos.DrawWireCube(pRaycastBoxPosition, new Vector3(pRaycastBox.x, 1, pRaycastBox.y));
        // Draw mirror side Raycast box.
        Gizmos.DrawWireCube(mRaycastBoxPosition, new Vector3(mRaycastBox.x, 1, mRaycastBox.y));
    }
}
