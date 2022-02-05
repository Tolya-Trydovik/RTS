using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 0.04f;
    float zoomSpeed = 10f;
    float rotateSpeed = 0.5f;

    float maxHeight = 70f;
    float minHeight = 10f;
    Vector2 p1;
    Vector2 p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.02f;
            zoomSpeed = 20f;
        }
        else
        {
            speed = 0.01f;
            zoomSpeed = 10f;
        }
        float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
        float vsp = transform.position.y * speed * Input.GetAxis("Vertical");
        float scrollSp = Mathf.Log(transform.position.y) * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        if((transform.position.y >= maxHeight) && (scrollSp > 0))
        {
            scrollSp = 0;
        }
        else if((transform.position.y <= minHeight) && (scrollSp < 0))
        {
            scrollSp = 0;
        }
        Vector3 verticalMove = new Vector3(0,scrollSp, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;
        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticalMove + lateralMove + forwardMove;

        transform.position += move;

        getCameraRotattion();
    }
    void getCameraRotattion()
    {
        if(Input.GetMouseButtonDown(1))
        {
            p1 = Input.mousePosition;
        }

        if(Input.GetMouseButton(1))
        {
            p2 = Input.mousePosition;

            float dx = (p2 - p1).x * rotateSpeed;
            float dy = (p2 - p1).y * rotateSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
            transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0, 0));
            p1 = p2;
        }
    }
}
