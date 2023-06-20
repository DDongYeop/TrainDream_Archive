using UnityEngine;

public class ArcballCameraLook : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private Vector3[] _position;
    [SerializeField] private Vector3[] _rotation;
    private SceneChanger _sceneChanger;

    private void Awake()
    {
        _sceneChanger = FindObjectOfType<SceneChanger>();
    }

    public void CameraPositionChange()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, _distance, 1 << 0);
        
        if (!isHit)
            return;

        switch (hit.collider.name)
        {
            case "Stencil01":
                LookPortal(2);
                _sceneChanger.StartSceneSelecter = StartSceneSelect.EXIT;
                break;
            case "Stencil02":
                LookPortal(3);
                _sceneChanger.StartSceneSelecter = StartSceneSelect.HELP;
                break;
            case "Stencil03":
                LookPortal(0);
                _sceneChanger.StartSceneSelecter = StartSceneSelect.TITLE;
                break;
            case "Stencil04":
                LookPortal(1);
                _sceneChanger.StartSceneSelecter = StartSceneSelect.STORY;
                break;
        }
    }

    private void LookPortal(int index)
    {
        transform.position = _position[index];
        transform.rotation = Quaternion.Euler(_rotation[index]);
    }
}
