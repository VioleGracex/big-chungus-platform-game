using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class wave_class : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] spawnpoint = new GameObject[3];
     
    void Start ()
    {
        
    }

    public Vector3Int get_cent(Vector3 cell)
    {
        //Vector3Int tempcell = tilemap.WorldToCell(cell);
        return tilemap.WorldToCell(cell);
    }
    
    // Update is called once per frame
    void Update ()
    {
        //Cursor.SetCursor(null, Vector2.zero, cursorMode);
        

    }
}
