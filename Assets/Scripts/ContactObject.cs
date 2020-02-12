using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactObject : MonoBehaviour
{
    public GameObject releaseButton;
    public PlacementObject placementObject;

    private void OnMouseDown()
    {
        releaseButton.SetActive(true);
        //placementObject.placed = false;
    }
}
