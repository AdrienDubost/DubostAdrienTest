using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    private RaycastHit hit;
    private Ray ray;
    #endregion
    private void Update()
    {
        if (Player.Instance.Departure)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Touch();
            }
        } 
    }
    private void Touch()
    {
        if(Input.touchCount > 0)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        }
        else
        {
            ray = Camera.main.ScreenPointToRay((Input.mousePosition)); 
        }
       
        if(Physics.Raycast(ray, out hit, 1000))
        {
            
            if (hit.collider.gameObject.tag == "Cube")
            {
                Book TmpBook = hit.collider.gameObject.GetComponent<Book>();
                if (TmpBook.Pushed)
                    TmpBook.Pull();
                else
                    TmpBook.Push(); 
            }
            else if(hit.collider.gameObject.tag == "Trap")
            {
                Debug.Log("Jesuiunchat");
                Trap TmpTrap = hit.collider.gameObject.GetComponent<Trap>();
                if(TmpTrap.Stop == false)
                {
                    TmpTrap.Stop = true; 
                } 
                else
                {
                    TmpTrap.Stop = false; 
                }
            }
        }
    }
}
