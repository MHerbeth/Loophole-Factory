using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Rigidbody _rigidbody;
    public Vector3 _speed = new Vector3();

    public Vector3 StartPosition = new Vector3();
    public Vector3 EndPosition = new Vector3();
    public Vector3 DistanceTravelled = new Vector3();
    private Vector3 _distanceTravelledNormalized = new Vector3();

    [SerializeField] private GameObject _trajectoryRenderer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();    }

    void OnMouseDown()
    {
        StartPosition = Input.mousePosition;
    }

    void OnMouseDrag()
    {
        EndPosition = Input.mousePosition;
        DistanceTravelled = EndPosition - StartPosition;
        _distanceTravelledNormalized = DistanceTravelled.normalized;
        _speed.x = Mathf.Lerp(0, 15f, Mathf.Abs(_distanceTravelledNormalized.x));
        _speed.y = Mathf.Lerp(0, 15f, Mathf.Abs(_distanceTravelledNormalized.y));
        if (_distanceTravelledNormalized.x < 0) _speed.x *= -1;
        if (_distanceTravelledNormalized.y < 0) _speed.y *= -1;
        if (DistanceTravelled.magnitude > 1)
        {
            if (_trajectoryRenderer.activeSelf == false)
            {
                _trajectoryRenderer.SetActive(true);
            }
        }
        else
        {
            _trajectoryRenderer.SetActive(false);
        }
    }

    void OnMouseUp()
    {
        _rigidbody.velocity -= _speed;
        _trajectoryRenderer.SetActive(false);
    }
}
