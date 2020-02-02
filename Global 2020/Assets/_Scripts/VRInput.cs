using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

// Reference: https://www.youtube.com/watch?v=vNqHRD4sqPc&list=PLmc6GPFDyfw85CcfwbB7ptNVJn5BSBaXz&index=3

public class VRInput : BaseInputModule
{
    public Camera m_camera;
    public SteamVR_Input_Sources targetSource;
    public SteamVR_Action_Boolean clickAction;

    private GameObject currentObject = null;
    private PointerEventData data = null;

    protected override void Awake()
    {
        base.Awake();

        data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        // Reset data, set camera
        data.Reset();
        data.position = new Vector2(m_camera.pixelWidth / 2, m_camera.pixelHeight / 2);

        // Raycast
        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        currentObject = data.pointerCurrentRaycast.gameObject;

        // Clear
        m_RaycastResultCache.Clear();

        // Hover
        HandlePointerExitAndEnter(data, currentObject);

        // Press
        if (clickAction.GetStateDown(targetSource))
            ProcessPress(data);

        // Release
        if (clickAction.GetStateUp(targetSource))
            ProcessRelease(data);

    }

    public PointerEventData GetData()
    {
        return data;
    }

    private void ProcessPress(PointerEventData dat)
    {
        // Set raycast
        dat.pointerPressRaycast = dat.pointerCurrentRaycast;

        // Check for hit, get down handler, call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(currentObject, dat, ExecuteEvents.pointerDownHandler);

        // If no down handler, try get click
        if (newPointerPress = null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        // Set data
        dat.pressPosition = dat.position;
        dat.pointerPress = newPointerPress;
        dat.rawPointerPress = currentObject;
    }

    private void ProcessRelease(PointerEventData dat)
    {
        // Pointer up
        ExecuteEvents.Execute(dat.pointerPress, dat, ExecuteEvents.pointerUpHandler);

        // Check cilck handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentObject);

        // Check if actual
        if(dat.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(dat.pointerPress, dat, ExecuteEvents.pointerClickHandler);
        }

        // Clear
        eventSystem.SetSelectedGameObject(null);

        // Reset data
        dat.pressPosition = Vector2.zero;
        dat.pointerPress = null;
        dat.rawPointerPress = null;
    }
}
