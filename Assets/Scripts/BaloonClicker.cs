using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaloonClicker : MonoBehaviour
{
    [SerializeField] mainPlayer player;
    [SerializeField] ObjectController baloon;
    private int ct = 0;

    [SerializeField] private TMP_Text textboxScore;
    [SerializeField] private TMP_Text textboxTime;

    // Start is called before the first frame update
    void Start()
    {
        player = mainPlayer.current;
        if(player != null)
        {
            Debug.Log("I see the player!");
        }
        textboxScore.text = "Score: " + ct;
        player.e_SelectedObject += Pop;
    }

    private void OnDestroy() {
        player.e_SelectedObject -= Pop;
    }

    private void Update() {
        textboxTime.text = "Time: "+Time.time;
    }

    void Pop(GameObject selectedObj)
    {
        baloon.TeleportRandomly();
        mainPlayer.Vibrate();

        ct++;
        textboxScore.text = "Score: " + ct;
    }
}
