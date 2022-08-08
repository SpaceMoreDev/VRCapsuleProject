using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> Objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject newBox = Instantiate(Objects[Random.Range(0, Objects.Count)]);
            newBox.transform.position = new Vector3(transform.position.x + Random.Range(-5, 5)
                                                    ,transform.position.y
                                                    ,transform.position.z);
            newBox.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 500);
            GameObject.Destroy(newBox, 5);

            yield return new WaitForSeconds(1);
        }
    }
}
