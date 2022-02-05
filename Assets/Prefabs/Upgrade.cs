using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    RaycastHit hit;
    Ray MyRay;
    public GameObject myPrefab;
    public GameObject MyFatherObj;
    void Start()
    {
        GameObject MyFatherObj = GameObject.Find("Canvas");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(MyRay.origin, MyRay.direction * 10, Color.yellow);
            if (Physics.Raycast(MyRay, out hit, 100))
            {
                MeshFilter filter = hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;
                if (filter)
                {
                    GameObject myPrefabButton = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    myPrefabButton.transform.parent = MyFatherObj.transform;
                }
            }
        }
    }
}
