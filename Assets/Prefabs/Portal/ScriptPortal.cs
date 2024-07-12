using UnityEngine;

public class ScriptPortal : MonoBehaviour
{
    private GameObject PlayerGameObject;
    private GameObject RoomGameObject;

    private void OnTriggerEnter(Collider other)
    {
        this.PlayerGameObject.transform.position = new Vector3(
            this.RoomGameObject.transform.position.x,
            this.PlayerGameObject.transform.position.y,
            this.RoomGameObject.transform.position.z);
    }

    public void setObjects(GameObject Room, GameObject Player)
    {
        this.RoomGameObject = Room;
        this.PlayerGameObject = Player;
    }
}
