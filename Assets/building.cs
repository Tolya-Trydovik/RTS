using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour

{
    public Vector2Int size = Vector2Int.one;
    public Renderer Renderer;

    public void SetTransparent(bool available)
    {
        if (available) Renderer.material.color = Color.green;
        else Renderer.material.color = Color.red;
    }
    public void SetNormal()
    {
        Renderer.material.color = Color.white;
    }
    private void OnDrawGizmos()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.y; z++)
            {
                if ((x + z) % 2 == 0)
                    Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                else
                    Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);
                Gizmos.DrawCube(transform.position + new Vector3(x, -0.55f, z), new Vector3(1f, 0.1f, 1f));
            }
        }
    }
}