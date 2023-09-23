using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour
{
    [SerializeField] private Launcher launcher;
    public mainPlayer _player;
    public ParticleSystem ps;
    public GameObject doors;


    private void Start() {
        if(mainPlayer.current == null)
        {
            launcher.SpawnedPlayer += Spawned;     
        }
        else
        {
            Spawned(mainPlayer.current.gameObject);
        }
    }

    private void Spawned(GameObject player)
    {
        _player = player.GetComponent<mainPlayer>();
        _player.e_SelectedObject += OnPointerClick;
    }

    private void OnDestroy() {
        _player.e_SelectedObject -= OnPointerClick;
        launcher.SpawnedPlayer -= Spawned; 
    }

    public void OnPointerClick(GameObject obj)
    {
        if(obj == this.gameObject)
        {
            Debug.Log("clicked on cake!");
            var em = ps.emission;
            em.enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            doors.SetActive(true);
        }
    }
}
