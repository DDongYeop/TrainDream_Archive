using UnityEngine;
using Core;

public class ArcballCamera : MonoBehaviour
{
    [SerializeField] private float _lotationSpeed; 
    private Camera _camera;
    private ArcballCameraLook _arcballCameraLook;
    private SceneChanger _sceneChanger;
    private Vector3 _previousPosition;

    private void Awake()
    {
        _camera = Define.MainCam;
        _arcballCameraLook = _camera.GetComponent<ArcballCameraLook>();
        _sceneChanger = GetComponent<SceneChanger>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) || _sceneChanger.ButtonInput())
        {
            _arcballCameraLook.CameraPositionChange();
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = _previousPosition - _camera.ScreenToViewportPoint(Input.mousePosition);
            
            //_camera.transform.RotateAround(new Vector3(), new Vector3(1, 0, 0), direction.y * 180);
            _camera.transform.RotateAround(new Vector3(), new Vector3(0, 1, 0), -direction.x * _lotationSpeed);

            _previousPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
