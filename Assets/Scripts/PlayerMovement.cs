using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent player;
    void Start()
    {
        cam = Camera.main;
        player = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //ÂÒÎË À Ã Ì‡Ê‡Ú 0 = À Ã; 1 = œ Ã
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}
