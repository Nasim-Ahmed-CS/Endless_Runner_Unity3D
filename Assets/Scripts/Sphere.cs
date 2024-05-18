using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float _zval;
    void Start()
    {
        transform.position = target.position;
        _zval = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z - _zval > 20)
        {
            Destroy(this.gameObject);
        }
        Vector3 newPosition = new Vector3(target.position.x, 2.5f, target.position.z);
        transform.position = newPosition;
        transform.Rotate(0, 45 * Time.deltaTime, 0);
    }
}
