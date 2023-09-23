using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    internal SerialController serialController;
    public float sensitivity=0.5f;
    //public Material highlight;
    [SerializeField] public bool canFall = true;
    public bool fall = false;
    public PostProcessVolume postProcessing;
    Vignette vignetteEffect;
    private Vector3 velocity = Vector3.zero;
    private GameObject _gazedAtObject = null;

    private void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
        postProcessing = postProcessing.GetComponent<PostProcessVolume>();
        postProcessing.profile.TryGetSettings(out vignetteEffect);
        vignetteEffect.active = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public bool moving = false;
    public Vector3 targetPosition;
    void Update()
    {

        if (transform.parent.position.y < -4)
        {
            SceneManager.LoadScene(0);
        }

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * sensitivity;
        
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     serialController.SendSerialMessage("Vibrate");
        //     Debug.Log("Sent Vibrate!");
        // }
        // else if(Input.GetKeyDown(KeyCode.B)){
        //     serialController.SendSerialMessage("Stop");
        //     Debug.Log("Stop Vibrate!");
        // }
        if(canFall)
        {
            if (fall == false)
            {
                vignetteEffect.active = false;
            }
            else
            {
                vignetteEffect.active = true;
            }
        
        CheckColor();
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //Debug.DrawLine(if (hit.transform.tag == "LookL"), transform.forward, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {

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
            //Debug.Log("clicked");
            _gazedAtObject?.SendMessage("OnPointerClick",gameObject); 
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            DisableVR();
            transform.Rotate(0, 180, 0);
            EnableVR();
        }


        if (moving)
        {
            transform.parent.position = Vector3.SmoothDamp(transform.parent.position, targetPosition, ref velocity, 0.1f);
            if (transform.parent.position == targetPosition) { moving = false; }
        }
        

    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = enable;
    }

    void EnableVR()
    {
        StartCoroutine(LoadDevice("daydream", true));
    }

    void DisableVR()
    {
        StartCoroutine(LoadDevice("", false));
    }


    public Material CheckColor()
    {
        RaycastHit hit;
        bool check = (Physics.Raycast(transform.parent.position, Vector3.down,out hit, 5f));
        if (check && hit.transform.gameObject.tag != "Player")
        {
            if (fall)
            {
                transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
                moving = false;
                hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            //Debug.Log(hit.transform.GetComponent<MeshRenderer>().material);
            return hit.transform.GetComponent<MeshRenderer>().material;
        }
        else
        {
            return null;
        }
    }
}
