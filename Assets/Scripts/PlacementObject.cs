using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementObject : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GraphicRaycaster raycaster;
    public ARPlaneManager planeManager;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//&& IsClickOverUI())
        {
            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.mousePosition, hitPoints, TrackableType.Planes);

            if (hitPoints.Count > 0)
            {
                Pose pose = hitPoints[0].pose;
                transform.rotation = pose.rotation;
                transform.position = pose.position;
                Vector3 currAngle = transform.eulerAngles;
                transform.LookAt(Camera.main.transform);
                transform.eulerAngles = new Vector3(currAngle.x, transform.eulerAngles.y, currAngle.z);
                closePlane();
            }
        }
    }

    bool IsClickOverUI()
    {
        PointerEventData data = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }

    public void closePlane()
    {
        planeManager.enabled = false;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }

    public void showPlane()
    {
        planeManager.enabled = true;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
    }
}