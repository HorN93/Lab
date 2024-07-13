using UnityEngine;

public class ScriptPortal : MonoBehaviour
{
    public GameObject PlayerGameObject;
    private Vector3 position;

    private void OnTriggerEnter(Collider other)
    {
        this.PlayerGameObject.transform.position = new Vector3(
            this.position.x,
            this.PlayerGameObject.transform.position.y,
            this.position.z);
    }

    public void setData(GameObject Player, Vector3 position)
    {
        this.position = position;
        this.PlayerGameObject = Player;
    }
}
