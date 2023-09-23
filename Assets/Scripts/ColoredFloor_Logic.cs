using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR;

public class ColoredFloor_Logic : MonoBehaviour
{
    [SerializeField][Range(1f,10f)]private float movement_speed;
    private mainPlayer _player;

    public bool fall = false;
    public PostProcessVolume postProcessing;
    public bool moving = false;
    public Transform targetPosition = null;
    public Vector3 velocity = Vector3.zero;
    public LayerMask panels;


    internal Vignette _vignetteEffect;
    internal SerialController serialController;

    private void Start() {

        _player = mainPlayer.current;
        _player.transform.position = transform.position;
        

        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        _player.GetComponent<Rigidbody>().useGravity = false;

        postProcessing = postProcessing.GetComponent<PostProcessVolume>();
        postProcessing.profile.TryGetSettings<Vignette>(out Vignette vignetteEffect);
        _vignetteEffect = vignetteEffect;
        _vignetteEffect.active = false;
        moving = false;
    }

    private void Update() {
        if(moving){
            Vector3 moveto = Vector3.MoveTowards(_player.transform.position, targetPosition.position, movement_speed * Time.deltaTime);
            moveto.y = _player.transform.position.y;
            _player.transform.position = moveto;

            if(Vector3.Distance(_player.transform.position, targetPosition.position) <= 0f)
            {
                moving = false;
                targetPosition = null;
            }
        }

    }

    //  IEnumerator LoadDevice(string newDevice, bool enable)
    // {
    //     XRSettings.LoadDeviceByName(newDevice);
    //     yield return null;
    //     XRSettings.enabled = enable;
    // }

    // void EnableVR()
    // {
    //     StartCoroutine(LoadDevice("daydream", true));
    // }

    // void DisableVR()
    // {
    //     StartCoroutine(LoadDevice("", false));
    // }


    public Material CheckColor()
    {
        RaycastHit hit;
        bool check = Physics.Raycast(_player.transform.position, Vector3.down,out hit, 5f,panels);
        if (check)
        {
            return hit.transform.GetComponent<MeshRenderer>().material;
        }
        else
        {
            // _player.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
            // hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            // vignetteEffect.active = true;
            // moving = false;

            if (targetPosition != null)
            {
                Material material = targetPosition.GetComponent<MeshRenderer>().material;
                return material;
            }
            return null;
        }
    }
}
