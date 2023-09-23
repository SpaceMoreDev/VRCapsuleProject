using System.Collections;
using UnityEngine;
using TMPro;
/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class ObjectController : MonoBehaviour
{
    /// <summary>
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;
    internal SerialController serialController;
    // public TMP_Text text;
    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float _minObjectDistance = 2f;
    private const float _maxObjectDistance = 3f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 1.5f;

    public Renderer _myRenderer;
    private Vector3 _startingPosition;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        _startingPosition = transform.parent.localPosition;
        SetMaterial(false);
    }

    /// <summary>
    /// Teleports this instance randomly when triggered by a pointer click.
    /// </summary>
    ///
    int ct = 0;
    public void TeleportRandomly()
    {

        float angle = Random.Range(-30, 30);
        float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
        float height = Random.Range(_minObjectHeight, _maxObjectHeight);

        Vector3 newPos = new Vector3(Mathf.Cos(angle), height,
                                     Mathf.Sin(angle) * distance);

        transform.localPosition = newPos;
        ct++;

        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
        TeleportRandomly();
        serialController.SendSerialMessage("A");
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}
