using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundTarget : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float Speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
        transform.RotateAround(Target.position, Vector3.down, Speed * Time.deltaTime);
    }
}
