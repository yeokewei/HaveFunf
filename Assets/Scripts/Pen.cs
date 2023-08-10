using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Pen : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("XR Interactable")]
    public XRBaseInteractable grabbableInteractable;
    List<InputDevice> inputDevices = new List<InputDevice>(); 

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;

    private bool isDrawing;

    private float triggerValue;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];
    }

    private void Update()
    {
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, inputDevices); 
        Debug.Log("current number of devices" + inputDevices.Count);
        foreach (var inputDevice in inputDevices) 
        { 
            inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue); 
            Debug.Log(inputDevice.name + " trigger value " + triggerValue); 
            
            inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue); 
            Debug.Log(inputDevice.name + " grip value  " + gripValue); 
             
            //Debug.Log(inputDevice.name + " " + inputDevice.characteristics); 
        } 

        bool isGrabbed = grabbableInteractable.isSelected;
        isDrawing = isGrabbed && triggerValue > 0.3f;

        if (isDrawing)
        {
            Draw();
        }
        else if (currentDrawing != null)
        {
            Destroy(currentDrawing.gameObject);
        }
        // else if (Input.GetButtonDown("primaryButton")) // Replace "ButtonName" with the button you want to use to switch colors
        // {
        //     SwitchColor();
        // }
    }

    private void Draw()
    {
        if (currentDrawing == null)
        {
            index = 0;
            currentDrawing = new GameObject().AddComponent<LineRenderer>();
            currentDrawing.material = drawingMaterial;
            currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
            currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
            currentDrawing.positionCount = 1;
            currentDrawing.SetPosition(0, tip.position);
        }
        else
        {
            var currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, tip.position) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, tip.position);
            }
        }
    }

    private void SwitchColor()
    {
        if (currentColorIndex == penColors.Length - 1)
        {
            currentColorIndex = 0;
        }
        else
        {
            currentColorIndex++;
        }
        tipMaterial.color = penColors[currentColorIndex];
    }
}
