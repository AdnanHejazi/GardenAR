using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Plane : MonoBehaviour
{
    public GameObject[] flowers;
    public XROrigin sessionOrigin;
    public ARPlaneManager planeManager;
    public ARRaycastManager raycastManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Shoot Raycast
            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            // Place the Objects Randomly
            if (collision)
            {
                GameObject _object = Instantiate(flowers[Random.Range(0, flowers.Length - 1)]);
                _object.transform.position = raycastHits[0].pose.position;
            }

            // Disable the Planes and Plane Manager
            foreach(var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            planeManager.enabled = false;


        }
    }
}
