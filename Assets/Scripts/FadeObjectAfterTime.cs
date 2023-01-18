using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObjectAfterTime : MonoBehaviour
{
    [SerializeField] GameObject ToHide;
    [SerializeField] float Delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideAfterSeconds(Delay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ToHide.gameObject.SetActive(false);
    }
}
