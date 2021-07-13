using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float RotationSpeed;
    private int InversionInt = 1;
    private Vector3 RotationAxis;
    public bool Stop;  

    // Start is called before the first frame update
    void Start()
    {
        Stop = false; 
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(); 
    }
    private void Rotation()
    {
        if (!Stop)
        {
            RotationAxis = new Vector3(RotationSpeed * Time.deltaTime, 0f, 0f);
            transform.Rotate(RotationAxis);
        }
    }
}
