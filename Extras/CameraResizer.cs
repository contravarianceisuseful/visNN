using System;
using UnityEngine;
using System.Collections;

public class CameraResizer : MonoBehaviour {

    public static float vertBuffer = 2;
    public static float horzBuffer = 3;

    public void ResizeToFitAll()
    {
        var left = FindFurtherestInDirection(new Vector2(-1,0));
        var right = FindFurtherestInDirection(new Vector2(1, 0));
        var up = FindFurtherestInDirection(new Vector2(0, 1));
        var down = FindFurtherestInDirection(new Vector2(0, -1));

        var cam = gameObject.GetComponent<Camera>();
        cam.orthographicSize = Math.Max(right - left + horzBuffer, up - down + vertBuffer);
        cam.transform.position = new Vector3((right - left)/2, (up - down)/2, -10);

    }

    private float FindFurtherestInDirection(Vector2 direction)
    {
        float maxDistance = 0;
        foreach (var go in GameObject.FindGameObjectsWithTag("CameraToFit"))
        {
            var mag = Vector3.Project((Vector2) go.transform.position, direction).magnitude;
            if ( mag > maxDistance)
            {
                maxDistance = mag;
            }
        }
        return maxDistance;
    }
}
