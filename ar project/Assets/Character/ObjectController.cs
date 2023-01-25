using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectController : MonoBehaviour
{
    public GameObject arobject;
    public ARRaycastManager raycastmanager;
    // Start is called before the first frame update
    void Start()
    {
        arobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch0 = Input.GetTouch(0);
            List<ARRaycastHit> allHits = new List<ARRaycastHit>();
            if (touch0.phase == TouchPhase.Began) {
                if (raycastmanager.Raycast(touch0.position, allHits, TrackableType.Planes)) {
                    arobject.transform.position = allHits[0].pose.position;
                    arobject.SetActive(true);
                }
            }
        }
    }
}
