using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPooling : MonoBehaviour {
    private static ObjectPooling instance = null;
    public static ObjectPooling Instance {
        get {
            if (instance == null)
            {
                instance = (ObjectPooling)FindObjectOfType(typeof(ObjectPooling));
                if (instance == null)
                    Debug.LogError("ObjectPooling instance is NULL. *Attach script to a GameObject!*");
            }
            return instance;
        }
    }
    private List<GameObject> _poolobjects;
    private GameObject poolObject;
    private int startingPool = 1;
    private bool wantToExpand = false;
    /// <summary>
    /// Initializes the ObjectPooling process [*Place in Start()*]
    /// </summary>
    /// <param name="_poolobj">The object to pool</param>
    /// <param name="_objname">Name of object</param>
    /// <param name="_startingpool">the amount of objects to pool</param>
    /// <param name="_isexpanding">increase the amount of objects in the pool when none is available</param>
	public void InitializePool(GameObject _poolobj,string _objname,int _startingpool = 1,bool _isexpanding=true)
    {
        //Initialize List
        if (_poolobjects == null)
        {
            _poolobjects = new List<GameObject>();
        }
        poolObject = _poolobj;
        startingPool = _startingpool;
        wantToExpand = _isexpanding;

        for (int i = 0; i < startingPool; i++)
        {
            GameObject obj = Instantiate(poolObject);
            obj.name = _objname;
            obj.SetActive(false);
            _poolobjects.Add(obj);
        }
    }
    /// <summary>
    /// Retrieve an object that is no longer active. If expand is true & all pool objects are active, add another object to the pool
    /// </summary>
    /// <param name="_objname">Name of object to get</param>
    /// <param name="_setposition">Set the starting position</param>
    /// <returns></returns>
    public GameObject getFalseObject(string _objname,Vector3 _setposition)
    {
        for (int i = 0; i < _poolobjects.Count; i++)
        {
            if (_poolobjects[i].name == _objname)
            {
                if (!_poolobjects[i].activeInHierarchy)
                {
                    _poolobjects[i].transform.position = _setposition;
                    return _poolobjects[i];
                }
            }
            
        }
        if (wantToExpand)
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            obj.transform.position = _setposition;
            _poolobjects.Add(obj);
            return obj;
        }
        return null;
    }
    /// <summary>
    /// Retrieve an object that is no longer active. If expand is true & all pool objects are active, add another object to the pool
    /// </summary>
    /// <param name="_objname">Name of object to get</param>
    /// <param name="_setposition">Set the starting position</param>
    /// <param name="_setrotation">Set the starting rotation</param>
    /// <returns></returns>
    public GameObject getFalseObject(string _objname, Vector3 _setposition,Quaternion _setrotation)
    {
        for (int i = 0; i < _poolobjects.Count; i++)
        {
            if (_poolobjects[i].name == _objname)
            {
                if (!_poolobjects[i].activeInHierarchy)
                {
                    _poolobjects[i].transform.position = _setposition;
                    _poolobjects[i].transform.rotation = _setrotation;
                    return _poolobjects[i];
                }
            }
        }
        if (wantToExpand)
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            obj.transform.position = _setposition;
            obj.transform.rotation = _setrotation;
            _poolobjects.Add(obj);
            return obj;
        }
        return null;
    }
}
