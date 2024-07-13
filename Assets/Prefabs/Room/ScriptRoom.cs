using UnityEngine;

public class ScriptRoom : MonoBehaviour
{
    public const int up = 0;
    public const int rt = 1;
    public const int dw = 2;
    public const int lt = 3;
    private const float shiftPortal = 5.0f;
    private const float shiftPosition = 3.8f;

    public GameObject PortalPrefab;

    public void CreatePortal(GameObject Room, GameObject Player, int direction)
    {
        Vector3 position;
        Vector3 roomPosition;
        switch (direction)
        {
            case up: {
                    position = new Vector3(0.0f, 0.0f, shiftPortal);
                    roomPosition = new Vector3(0.0f, 0.0f, -shiftPosition);
                } break;
            case rt: {
                    position = new Vector3(shiftPortal, 0.0f, 0.0f);
                    roomPosition = new Vector3(-shiftPosition, 0.0f, 0.0f);
                } break;
            case dw: {
                    position = new Vector3(0.0f, 0.0f, -shiftPortal);
                    roomPosition = new Vector3(0.0f, 0.0f, shiftPosition);
                } break;
            case lt: {
                    position = new Vector3(-shiftPortal, 0.0f, 0.0f);
                    roomPosition = new Vector3(shiftPosition, 0.0f, 0.0f);
                } break;
            default: {
                    position = new Vector3(0.0f, 0.0f, 0.0f);
                    roomPosition = new Vector3(shiftPosition, 0.0f, 0.0f);
                } break;
        }

        GameObject newPortal = Instantiate(this.PortalPrefab, this.transform.position + position, Quaternion.Euler(0, 0, 0));
        newPortal.GetComponent<ScriptPortal>().setData(
            Player,
            roomPosition + Room.transform.position
        );
    }
}