using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    public Vector3 _cameraShift = new Vector3(-0.1f, 0, 0);
    protected Transform _trPl;

        // Start is called before the first frame update
    void Start()
    {
        _trPl = Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _trPl.TransformPoint(_cameraShift);
        this.transform.LookAt(Player.transform.position);
    }
}
