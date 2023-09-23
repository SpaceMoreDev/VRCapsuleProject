using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private mainPlayer player;
    private int tileID = -1;
    private ColoredFloor_Logic colorLogic;
    private void Start() {
        player = mainPlayer.current;
        tileID = Random.Range(0,999999);
        colorLogic = FindObjectOfType<ColoredFloor_Logic>();
        player.e_SelectedObject += this.OnPointerClick;
    }

    private void OnDestroy() {
        player.e_SelectedObject -= this.OnPointerClick;
    }

    public void OnPointerClick(GameObject obj)
    {
        if(obj.TryGetComponent<Tile>(out Tile tile))
        {
            if(this.tileID == tile.tileID)
            {
                Debug.Log("clicked!");
                colorLogic.targetPosition = this.transform;
                colorLogic.moving = true;
            }
        }
    }

   
}
