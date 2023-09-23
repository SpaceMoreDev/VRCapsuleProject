using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switcher_Door : MonoBehaviour
{
    [SerializeField] private int sceneNum = 0;
    [SerializeField] private Material InactiveMaterial;
    [SerializeField] private Material GazedAtMaterial;
    [SerializeField] private Renderer _myRenderer;

    private mainPlayer _player;

    private void OnEnable() {
        _player = mainPlayer.current;
        _player.e_PointerEnter += OnPointerEnter;
        _player.e_PointerExit += OnPointerExit;
        _player.e_SelectedObject += OnPointerClick;
    }

    private void OnDestroy() {
        _player.e_PointerEnter -= OnPointerEnter;
        _player.e_PointerExit -= OnPointerExit;
        _player.e_SelectedObject -= OnPointerClick;
    }

    public void OnPointerEnter(GameObject obj)
    {
        if(obj == this.gameObject)
        {
            SetMaterial(true);
        } 
    }

    public void OnPointerExit(GameObject obj)
    {
        if(obj == this.gameObject)
        {
            SetMaterial(false);
        }
    }

    public void OnPointerClick(GameObject obj)
    {
        if(obj == this.gameObject)
        {
            SceneManager.LoadScene(sceneNum);
        }
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

}
