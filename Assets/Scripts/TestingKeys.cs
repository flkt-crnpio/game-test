using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) {
            Debug.Log("brincar mouse y space");
        }

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        if (_horizontal != 0) {
            Debug.Log("eje x = " + _horizontal);
        }
        if (_vertical != 0) {
            Debug.Log("eje y = " + _vertical);
        }
    }
}
