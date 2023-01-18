using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> Path = null;
    [SerializeField] Animator Animator = null;
    [SerializeField] float Speed = 1f;
    [SerializeField] float StartDelay = 1f;
    [SerializeField] bool Activated = false;
    [SerializeField] KeyCode ActivationKey;
    Transform _currentTarget = null;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        _currentTarget = Path[index].transform;
        Activate();
      
    }
    public void Activate()
    {
        StartCoroutine(StartMoveDelay(StartDelay));
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Activated)
        {
            var step = Speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, _currentTarget.position) < 0.001f)
            {
                index++;
                if (index >= Path.Count)
                    index = 0;
                _currentTarget = Path[index].transform;
            }
        }
        Animator.SetBool("Flying", Activated);
    }
    IEnumerator StartMoveDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Activated = true;
        Animator.SetBool("Flying", Activated);
    }
    
}
