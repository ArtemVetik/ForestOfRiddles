using UnityEngine;

public class BackScreamer : MonoBehaviour
{
    private const float Lifetime = 10f;
    private const float VisibleDistance = 15f;

    [SerializeField] private Canvas _screamerCanvas;

    private Camera _playerView;

    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    public void Init(Camera playerView)
    {
        _playerView = playerView;
    }

    private void Update()
    {
        if (IsVisible(transform.position, Vector3.one, _playerView))
        {
            Instantiate(_screamerCanvas);
            Destroy(gameObject);
        }
    }

    private bool IsVisible(Vector3 position, Vector3 boundSize, Camera camera)
    {
        if (Vector3.Distance(transform.position, position) > VisibleDistance)
            return false;

        var bounds = new Bounds(position, boundSize);
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
