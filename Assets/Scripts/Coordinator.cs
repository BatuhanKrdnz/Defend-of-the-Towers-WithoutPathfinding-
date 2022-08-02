using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coordinator : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.gray;
    TextMeshPro labels;
    Vector2Int coordinates = new Vector2Int();

    WayPoint waypoint;
    void Awake() 
    {
        labels = GetComponent<TextMeshPro>();
        labels.enabled = false;
        
        waypoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            labels.enabled = !labels.IsActive();
        }
    }
    private void SetLabelColor()
    {
        if(waypoint.IsPlaceable)
        {
            labels.color = defaultColor;
        }
        else
        {
            labels.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        
        labels.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
