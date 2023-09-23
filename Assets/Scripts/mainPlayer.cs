using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainPlayer : MonoBehaviour
{  
    [SerializeField] LayerMask selectLayer;
    [SerializeField] float sensitivity = 0.5f;
    public static mainPlayer current;

    private Vector2 rotation = Vector2.zero;
    private const float _maxDistance = 50;
    private GameObject _gazedAtObject = null;

    public event Action<GameObject> e_SelectedObject;
    public event Action<GameObject> e_PointerEnter;
    public event Action<GameObject> e_PointerExit;

    private void Awake() {
        current = this;
    }

    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * sensitivity;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, selectLayer))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                e_PointerEnter?.Invoke(_gazedAtObject);
            }
        }
        else
        {   e_PointerExit?.Invoke(_gazedAtObject);
            if(_gazedAtObject != null)
            {            
                // No GameObject detected in front of the camera.    
                _gazedAtObject = null;
            }
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed){
            Select();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Joystick1Button1)){
            Select();
        }
    }

    private void Select()
    {
        // _gazedAtObject?.SendMessage("");
        if(_gazedAtObject != null)
        {
            e_SelectedObject?.Invoke(_gazedAtObject);
        }
    }
}
