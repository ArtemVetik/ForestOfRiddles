using UnityEngine;

public class EyeSpawnPosition
{
    private readonly Bounds _bounds;
    private readonly float _minDistance;
    private readonly float _maxDistance;

    public EyeSpawnPosition(Bounds bounds, float minDistance, float maxDistance)
    {
        _bounds = bounds;
        _minDistance = minDistance;
        _maxDistance = maxDistance;
    }

    public bool TryGenerateSpawnPosition(Transform point, out Vector3 position)
    {
        var planeForward = new Vector3(point.forward.x, 0, point.forward.z).normalized;
        var nearestDistance = point.position + planeForward * _minDistance;
        var largestDistance = point.position + planeForward * _maxDistance;

        if (_bounds.Contains(nearestDistance) && _bounds.Contains(largestDistance))
        {
            position = point.position + planeForward * (Random.Range(_minDistance, _maxDistance));
            return true;
        }

        position = Vector3.zero;
        return false;
    }
}
