using UnityEngine;

public class ScriptRoom : MonoBehaviour
{
    public const int up = 0;
    public const int rt = 1;
    public const int dw = 2;
    public const int lt = 3;
    private const float shiftPortal = 4.9f;

    public GameObject PortalPrefab;

    //GameObject Room, GameObject Player, int direction
    public void CreatePortal(GameObject Room, GameObject Player, int direction)
    {
        Vector3 position;
        switch (direction)
        {
            case up: { position = new Vector3(0.0f, 0.0f, shiftPortal); } break;
            case rt: { position = new Vector3(shiftPortal, 0.0f, 0.0f); } break;
            case dw: { position = new Vector3(0.0f, 0.0f, -shiftPortal); } break;
            case lt: { position = new Vector3(-shiftPortal, 0.0f, 0.0f); } break;
            default: { position = new Vector3(0.0f, 0.0f, 0.0f); } break;
        }

        GameObject newPortal = Instantiate(this.PortalPrefab, this.transform.position + position, Quaternion.Euler(0, 0, 0));
        newPortal.GetComponent<ScriptPortal>().setObjects(Room, Player);
    }
}