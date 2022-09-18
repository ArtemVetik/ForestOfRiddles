using System.Collections;
using UnityEngine;

public class EyeScreamerSpawner : MonoBehaviour
{
    [SerializeField] private Bounds _bound;
    [SerializeField] private Transform _player;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _spawnDelay;
    [Header("Prefabs")]
    [SerializeField] private EyeScreamer _eyeScreamerTemplate;

    private EyeSpawnPosition _spawnPosition;

    private void Start()
    {
        _spawnPosition = new EyeSpawnPosition(_bound, _minDistance, _maxDistance);
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        var retryDelay = new WaitForSeconds(1f);

        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            Vector3 spawnPosition;
            while (_spawnPosition.TryGenerateSpawnPosition(_player, out spawnPosition) == false)
                yield return retryDelay;

            var screamer = Instantiate(_eyeScreamerTemplate, spawnPosition, Quaternion.identity);
            screamer.Init(_player);
        }
    }
}
