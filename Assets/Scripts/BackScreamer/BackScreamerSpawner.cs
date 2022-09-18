using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BackScreamerSpawner : MonoBehaviour
{
    private const float SpawnDistance = 4f;

    [SerializeField] private Camera _playerView;
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnDelay;
    [Header("Prefab")]
    [SerializeField] private BackScreamer _template;

    private Coroutine _spawner;

    public event UnityAction<BackScreamer> Spawned;

    private void OnEnable()
    {
        _spawner = StartCoroutine(SpawnLoop());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawner);
    }

    private IEnumerator SpawnLoop()
    {
        var delay = new WaitForSeconds(_spawnDelay);
        while (true)
        {
            yield return delay;

            var spawnPosition = _player.position - _player.forward * SpawnDistance;

            var screamer = Instantiate(_template, spawnPosition, Quaternion.identity);
            screamer.Init(_playerView);

            Spawned?.Invoke(screamer);
        }
    }
}
