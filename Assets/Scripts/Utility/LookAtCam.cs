using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    private Transform cameraTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform = Camera.main.transform;
        transform.LookAt(cameraTransform);
    }
}
