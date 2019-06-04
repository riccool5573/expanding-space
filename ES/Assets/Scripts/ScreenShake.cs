using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Transform transform;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    private bool opens;
    private bool done;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Button = GameObject.Find("button");
        button cs = Button.GetComponent<button>();
        opens = cs.active;
        if (opens && !done)
        {
            TriggerShake();
            done = true;
        }
        if(!opens && done)
        {
            done = false;

        }
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }

    }
    public void TriggerShake()
    {
        shakeDuration = 2.0f;
        Debug.Log("got here");
    }
}
