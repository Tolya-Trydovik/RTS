using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingread : MonoBehaviour
{
    public Vector2Int gridsize = new Vector2Int(30,30);
    private Camera camera;
    private building flyingbuilding;
    private building [,] Grid;

    RaycastHit hit;
    Ray MyRay;
    void Start()
    {
        camera = Camera.main;
        Grid = new building[gridsize.x, gridsize.y];

        GameObject MyFatherObj = GameObject.Find("Canvas");
    }
    public void StartingPlacingBuilding(building buildingPrefab)
    {
        if(flyingbuilding != null)
        {
            Destroy(flyingbuilding.gameObject);
        }

        flyingbuilding = Instantiate(buildingPrefab);
    }
    void Update()
    {
        if(flyingbuilding != null)
        {
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                int x = Mathf.RoundToInt(worldPosition.x);
                int z = Mathf.RoundToInt(worldPosition.z);

                flyingbuilding.transform.position = new Vector3(x, 0, z);

                bool available = true;

                if (x < 0 || x > gridsize.x - flyingbuilding.size.x)
                    available = false;
                if (z < 0 || z > gridsize.y - flyingbuilding.size.y)
                    available = false;

                if (available && IsPlaceTaken(x, z))
                    available = false;

                flyingbuilding.SetTransparent(available);

                if (available && Input.GetMouseButtonDown(0))
                    PlaceBuilding(x, z);
            }
        }
        //MOUSE1 UPGRADE=============================
        //===========================================
    }
    private void PlaceBuilding(int placeX, int placeZ)
    {
        for (int x = 0; x < flyingbuilding.size.x; x++)
        {
            for (int z = 0; z < flyingbuilding.size.y; z++)
            {
                Grid[placeX + x, placeZ + z] = flyingbuilding;
                Debug.Log(placeX);
                Debug.Log(placeZ);
            }
        }
        flyingbuilding.SetNormal();
        flyingbuilding = null;
    }

    private bool IsPlaceTaken(int placeX, int placeZ)
    {
        for (int x = 0; x < flyingbuilding.size.x; x++)
        {
            for (int z = 0; z < flyingbuilding.size.y; z++)
            {
                if (Grid[placeX + x, placeZ + z] !=null) return true;
            }
        }
        return false;

    }
}
