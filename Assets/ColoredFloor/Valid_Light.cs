using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valid_Light : MonoBehaviour
{
    [SerializeField] private Ground_Lights groundScript;
    [SerializeField] private Player player;
    [SerializeField] private Vector3 playerLoc = Vector3.zero;
    [SerializeField] public GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        //groundScript.Get_inside_children();
        StartCoroutine(timer());
        playerLoc = player.transform.position;
    }

    // Update is called once per frame

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z -15f);

        if (player.transform.position.z < playerLoc.z-9)
        {
            playerLoc = player.transform.position;
            map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y, map.transform.position.z-9.25f);
        }
    }

    void excute_after_timer()
    {
        if (player.CheckColor().color != this.GetComponent<MeshRenderer>().material.color)
        {
            player.fall = true;
        }

        //Debug.Log("player= " + player.CheckColor().color + ", panel= " + this.GetComponent<MeshRenderer>().material.color);
        groundScript.Get_inside_children();
        transform.GetComponent<MeshRenderer>().material = groundScript.colors[Random.Range(0, groundScript.colors.Count)];
        //Debug.Log("executed");
        StartCoroutine(timer());
    }
    IEnumerator timer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

            for (int i = 0; i < transform.childCount; i++)
        {
            yield return new WaitForSeconds(0.6f);
            transform.GetChild(i).gameObject.SetActive(false);
        }
        excute_after_timer();
    }
}
