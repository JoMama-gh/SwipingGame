using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShapeFill : MonoBehaviour {
    [SerializeField] Vector2 sampleBoxSize; // x, z
    [SerializeField] float sampleDistance;
    [SerializeField] float randomJitter;
    [SerializeField] LayerMask shapeColliderMask;
    [SerializeField] GameObject fillPrefab;
    [SerializeField] int fillCount;
    
    List<Vector3> FindInsidePoints() {
        Vector2Int sampleCounts = Vector2Int.FloorToInt(sampleBoxSize / sampleDistance);
        // TODO: var fixedSampleDistances = new Vector2()...
        var points = new List<Vector3>();
        for (int i = 0; i < sampleCounts.x; i++) {
            for (int j = 0; j < sampleCounts.y; j++) {
                var p0 = transform.position;
                p0.x -= sampleBoxSize.x / 2;
                p0.z -= sampleBoxSize.y / 2;
                var p = p0 + 
                        (i * sampleDistance + Random.Range(-1, 1) * randomJitter) * Vector3.right +
                        (j * sampleDistance + Random.Range(-1, 1) * randomJitter) * Vector3.forward;
                var hits = Physics.OverlapSphere(p, 0.1f, shapeColliderMask);
                if (hits.Length > 0) {
                    points.Add(p);
                }
            }
        }
        return points;
    }

    void InstantiateAtRandom(List<Vector3> points, int howMany) {
        if (points.Count < howMany) {
            Debug.LogError("yo this aint enough points");
            return;
        }
        while (howMany > 0) {
            int index = Random.Range(0, points.Count);
            var point = points[index];
            Instantiate(fillPrefab, point, Quaternion.identity);
            points.RemoveAt(index);
            howMany--;
        }    
    }
    
    void Start() {
        var points = FindInsidePoints();
        // debug: show all points
        // foreach (var point in points) {
        //     Instantiate(fillPrefab, point, Quaternion.identity);
        // }
        InstantiateAtRandom(points, fillCount);
        
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, 
            new Vector3(sampleBoxSize.x, 1, sampleBoxSize.y));
    }
}
