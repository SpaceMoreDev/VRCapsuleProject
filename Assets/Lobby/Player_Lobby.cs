using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lobby : MonoBehaviour
{
    private GameObject _gazedAtObject = null;
    Vector2 rotation = Vector2.zero;
    public float sensitivity=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        // rotation.y += Input.GetAxis("Mouse X");
        // rotation.x += -Input.GetAxis("Mouse Y");
        // transform.eulerAngles = (Vector2)rotation * sensitivity;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f))
        {
            //Debug.Log(hit.transform.name);
            if ( _gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
            
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            _gazedAtObject?.SendMessage("OnPointerClick"); 
        }
    }
}
