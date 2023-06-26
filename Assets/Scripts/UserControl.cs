using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    [SerializeField] Camera GameCamera;
    [SerializeField] GameObject Marker;
    private CharacterController m_Selected = null;

    private void Start()
    {
        Marker.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (m_Selected != null && Input.GetMouseButtonDown(1))
        {//right click give order to the unit
            HandleAction();
        }

        MarkerHandling();
    }
    
    // Handle displaying the marker above the unit that is currently selected (or hiding it if no unit is selected)
    void MarkerHandling()
    {
        if (m_Selected == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }
        else if (m_Selected != null && Marker.transform.parent != m_Selected.transform)
        {
            Marker.SetActive(true);
            Marker.transform.SetParent(m_Selected.transform, true);
            Marker.transform.localPosition = Vector3.up;
        }    
    }

    public void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit);
            //the collider could be children of the unit, so we make sure to check in the parent
            var character = hit.collider.GetComponentInParent<CharacterController>();
            m_Selected = character;        
            
            //check if the hit object have a IUIInfoContent to display in the UI
            //if there is none, this will be null, so this will hid the panel if it was displayed
            // var uiInfo = hit.collider.GetComponentInParent<UIMainScene.IUIInfoContent>();
            // UIMainScene.Instance.SetNewInfoContent(uiInfo);
        }
    }

    public void HandleAction()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // var building = hit.collider.GetComponentInParent<Building>();
            
            // if (building != null)
            // {
            //     m_Selected.GoTo(building);
            // }
            // else
            // {
            //     m_Selected.GoTo(hit.point);
            // }
        }
    }
}
