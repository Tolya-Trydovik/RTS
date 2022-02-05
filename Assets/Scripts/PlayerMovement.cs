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
        if(Input.GetMouseButtonDown(0)) //���� ��� ����� 0 = ���; 1 = ���
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}
