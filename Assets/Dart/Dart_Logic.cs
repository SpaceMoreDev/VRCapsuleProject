using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dart_Logic : MonoBehaviour
{
    [SerializeField] private TMP_Text textScore;

    // internal SerialController serialController;
    internal int ct = 0;
    // Start is called before the first frame update
    void Start()
    {
        textScore.text = $"Score: {ct}";
        
        // serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        mainPlayer.current.transform.position = transform.position;
        mainPlayer.current.e_SelectedObject += CheckItemIfBad;
    }
    private void OnDestroy() {
        mainPlayer.current.e_SelectedObject -= CheckItemIfBad;
    }

    void CheckItemIfBad(GameObject obj)
    {
        if(obj.tag == "Good")
        {
            Destroy(obj);
            ct += 1;
            Debug.Log("good job!");
        }
        else if(obj.tag == "Bad")
        {
            Destroy(obj);
            ct -= 1;
            Debug.Log("OH NO!");
        }

        textScore.text = $"Score: {ct}";
    }

    // Update is called once per frame
    void Update()
    {
        if (ct < 0)
        {
            mainPlayer.Vibrate();
            SceneManager.LoadScene(0);
        }
    }
}
