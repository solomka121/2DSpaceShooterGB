using UnityEngine;

public class CameraController
{
    private Transform _objectToFollow;
    private Camera camera;
    private Vector3 _offset;
    public CameraController( Camera main , Transform objectToFollow)
    {
        camera = main;
        _objectToFollow = objectToFollow;

        _offset = camera.transform.position - objectToFollow.position;
    }

    public void LateExecute()
    {
        Vector3 nextPosition = Vector3.Slerp( camera.transform.position ,
            _objectToFollow.transform.position + _offset, 0.01f);

        camera.transform.position = nextPosition;
    }
}
