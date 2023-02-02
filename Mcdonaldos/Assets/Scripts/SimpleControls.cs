using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControls : MonoBehaviour
{

    [SerializeField] private float velocity = 10.0f;
    void PleaseMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(0, 0, 1) * velocity
                * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(0, 0, 1) * -velocity 
                * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(1, 0, 0) * velocity
                * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(1, 0, 0) * -velocity 
                * Time.deltaTime;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PleaseMove();
    }
}
