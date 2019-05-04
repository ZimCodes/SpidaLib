using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IFOV
{
    void Start();
    List<GameObject> GetAllVisibleObjects(Transform _transform);
    GameObject GetFirstVisibleObject(Transform _transform, params SightAspect.AspectName[] _aspects);
    void OnDrawGizmos(Transform _transform, bool _isDebugOn);
}
public class FOV :IFOV
{
    private float sightDistance;
    private float fieldOfView;
    private LayerMask ignoreRayLayer;//all objects within IgnoreRaycast will be ignored
    private List<GameObject> visibleTargets;
    public FOV(float _fov, float _radius)
    {
        visibleTargets = new List<GameObject>();
        fieldOfView = _fov;
        sightDistance = _radius;
    }
    public void Start()
    {
        ignoreRayLayer = 1 << LayerMask.NameToLayer("Ignore Raycast");
        ignoreRayLayer = ~ignoreRayLayer;
    }
    /// <summary>
    /// Retrieves objects that are within field of view
    /// </summary>
    private void FieldOfVision(Transform _transform)
    {
        if (visibleTargets.Count > 0)
        {
            visibleTargets.Clear();
        }
        //Get objects within radius
        Collider[] objsInView = Physics.OverlapSphere(_transform.position, sightDistance, ignoreRayLayer);
        for (int i = 0; i < objsInView.Length; i++)
        {
            Vector3 dirToObj = (objsInView[i].transform.position - _transform.position).normalized;
            //Check if object is within field of view
            if (Vector3.Angle(_transform.forward, dirToObj) <= fieldOfView / 2)
            {
                //Check if object is within sight radius
                if (Physics.Raycast(_transform.position, dirToObj, sightDistance, ignoreRayLayer))
                {
                    //add object within field of view and sight radius into list
                    visibleTargets.Add(objsInView[i].gameObject);
                }
            }
        }
    }
    /// <summary>
    /// Get all Visible objects that are seen 
    /// </summary>
    /// <param name="_transform">this transform</param>
    /// <returns>returns all visible objects</returns>
    public List<GameObject> GetAllVisibleObjects(Transform _transform)
    {
        FieldOfVision(_transform);
        return visibleTargets;
    }
    /// <summary>
    /// Retrieve the first visible object
    /// </summary>
    /// <param name="_transform">this Transform</param>
    /// <returns>returns the visible object</returns>
    public GameObject GetFirstVisibleObject(Transform _transform)
    {
        FieldOfVision(_transform);
        if (visibleTargets.Count > 0)
        {
            return visibleTargets[0];
        }
        return null;
    }
    /// <summary>
    /// Retrieve the first visibleobject of a specific type[*Object needs to have SightAspect script attached to them to use this*]
    /// </summary>
    /// <param name="_transform">this Transform</param>
    /// <param name="_aspects">Specfic Aspect Type tp look for</param>
    /// <returns>returns the visible object of a specific type</returns>
    public GameObject GetFirstVisibleObject(Transform _transform, params SightAspect.AspectName[] _aspects)
    {
        FieldOfVision(_transform);
        for (int i = 0; i < visibleTargets.Count; i++)
        {
            SightAspect targetAspect = visibleTargets[i].GetComponent<SightAspect>();
            //Check if visible object has aspect script 
            if (targetAspect != null)
            {
                for (int j = 0; j < _aspects.Length; j++)
                {
                    if (targetAspect.aspect == _aspects[j])
                    {
                        return visibleTargets[i];
                    }
                }
            }
        }
        return null;
    }

    #region Debug
    public void OnDrawGizmos(Transform _transform, bool _isDebugOn)
    {
        if (_isDebugOn)
        {
            Vector3 leftDir = (_transform.right * -1);
            Vector3 forwardDir = _transform.forward;
            Vector3 rightDir = _transform.right;
            //Left
            Debug.DrawLine(_transform.position, _transform.position + Vector3.Slerp(forwardDir, leftDir, (fieldOfView / 2) / 90) * sightDistance, Color.red);
            //Right
            Debug.DrawLine(_transform.position, _transform.position + Vector3.Slerp(forwardDir, rightDir, (fieldOfView / 2) / 90) * sightDistance, Color.red);
            if (visibleTargets.Count > 0)
            {
                for (int i = 0; i < visibleTargets.Count; i++)
                {
                    Debug.DrawLine(_transform.position, visibleTargets[i].transform.position, Color.cyan);
                }
            }
        }
    }
    #endregion
}
