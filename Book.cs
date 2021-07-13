using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Material PushedMat; 
    [SerializeField]
    private Material PulledMat;
    [SerializeField]
    private float PushAndPulledDistance;
    public float VerticalPushPullDistance; 
    public bool Pushed;
    #endregion

    private void Start()
    {
        if (Pushed)
        {
            Push(); 
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = PulledMat;
        }
    }
    public void Push()
    {
        Pushed = true; 
        gameObject.GetComponent<MeshRenderer>().material = PushedMat;
        transform.position += new Vector3(0, VerticalPushPullDistance, PushAndPulledDistance);
    }
    public void Pull()
    {
        Pushed = false; 
        Debug.Log("PiouPiou"); 
        gameObject.GetComponent<MeshRenderer>().material = PulledMat;
        transform.position += new Vector3(0, -VerticalPushPullDistance, -PushAndPulledDistance);
    }
}
