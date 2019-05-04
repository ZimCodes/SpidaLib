using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Use this with 'FollowPath' script
public class Path : MonoBehaviour {
    [SerializeField]
    private Vector3[] pointA = new Vector3[8];
    public float radius = 2.0f;
    public int Length { get { return pointA.Length; } }

    public Vector3 GetPoint(int index)
    {
        return pointA[index];
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pointA.Length; i++)
        {
            if (i + 1 != pointA.Length)
            {
                Debug.DrawLine(pointA[i], pointA[i + 1], Color.yellow);
            }
            
        }
    }
}
