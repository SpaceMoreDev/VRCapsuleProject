using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Google.XR.Cardboard;
using UnityEngine.XR.Management;
public class SwitchScene : MonoBehaviour
{
    [SerializeField] TMP_InputField field;
    [SerializeField] Data data;
    private void Awake()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
    }

    public void Switch(int scene)
    {
        if (field.text != "")
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            data.ipAddress = field.text;
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.Log("didnt enter an IP");
        }
    }
}
