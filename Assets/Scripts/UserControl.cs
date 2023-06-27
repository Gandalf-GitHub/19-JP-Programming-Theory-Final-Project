using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    [SerializeField] Camera GameCamera;
    [SerializeField] GameObject renamePanel;
    [SerializeField] TMP_Text currentName;
    [SerializeField] TMP_InputField newNameField;
    private EntityController selected = null;

    private void Start()
    {
        
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (selected != null && Input.GetMouseButtonDown(1))
        {//right click give order to the unit
            HandleAction();
        }

        if (selected != null && Input.GetKeyDown(KeyCode.R))
        {
            ShowRenamePanel();
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
                
                selected = hit.collider.GetComponentInParent<EntityController>();
                selected.Selected = true;
                selected.ShowMarker(true);
            }
            
        }
    }

    public void HandleAction()
    {
        foreach (GameObject entity in GameObject.FindGameObjectsWithTag("Player"))
        {
            entity.GetComponent<EntityController>().Selected = false;
            entity.GetComponent<EntityController>().ShowMarker(false);
        }
    }

    void ShowRenamePanel()
    {
        currentName.text = $"Current name: {selected.Name}";
        renamePanel.SetActive(true);
    }

    public void RenameCharacter()
    {
        string newName = newNameField.text;

        if (!string.IsNullOrEmpty(newName) && !string.IsNullOrWhiteSpace(newName))
        {
            selected.Name = newName;
        }

        renamePanel.SetActive(false);
    }
}
