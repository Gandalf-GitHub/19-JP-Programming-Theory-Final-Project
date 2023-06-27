using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    [SerializeField] Camera GameCamera;
    private EntityController m_Selected = null;

    private void Start()
    {
        
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

    }

    public void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                foreach (GameObject entity in GameObject.FindGameObjectsWithTag("Player"))
                {
                    entity.GetComponent<EntityController>().Selected = false;
                    entity.GetComponent<EntityController>().ShowMarker(false);
                }
                //the collider could be children of the unit, so we make sure to check in the parent
                var character = hit.collider.GetComponentInParent<EntityController>();
                m_Selected = character;
                character.Selected = true;
                character.ShowMarker(true);
                
                //check if the hit object have a IUIInfoContent to display in the UI
                //if there is none, this will be null, so this will hid the panel if it was displayed
                // var uiInfo = hit.collider.GetComponentInParent<UIMainScene.IUIInfoContent>();
                // UIMainScene.Instance.SetNewInfoContent(uiInfo);
            }
            
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
