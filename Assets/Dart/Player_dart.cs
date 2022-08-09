using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_dart : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float sensitivity = 0.5f;
    //public Material highlight;
    public bool fall = false;
    public PostProcessVolume postProcessing;
    Vignette vignetteEffect;

    public TMP_Text textbox;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
        postProcessing = postProcessing.GetComponent<PostProcessVolume>();
        postProcessing.profile.TryGetSettings(out vignetteEffect);
        vignetteEffect.active = false;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    int ct=0;
    // Update is called once per frame
    void Update()
    {
        //rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");
        //transform.eulerAngles = (Vector2)rotation * sensitivity;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f))
        {
            //Debug.Log(hit.transform.name);

            if (Google.XR.Cardboard.Api.IsTriggerPressed || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Debug.Log("clicked");
                if (hit.transform.gameObject.tag == "Good")
                {
                    Destroy(hit.transform.gameObject);
                    ct += 1;
                    Debug.Log("good job!");
                }
                else if (hit.transform.gameObject.tag == "Bad")
                {
                    Destroy(hit.transform.gameObject);
                    ct -= 1;
                    Debug.Log("ew what is that?");

                }
                else if (hit.transform.gameObject.tag == "door")
                {
                    hit.transform.SendMessage("OnPointerClick");
                }
            }
        }

        if (ct < 0)
        {
            SceneManager.LoadScene(3);
        }

        textbox.text = "Score: " + ct;
    }
}
