using System.Collections;
using UnityEngine;

public class BackScreamerSpawner : MonoBehaviour
{
    private const float SpawnDistance = 4f;

    [SerializeField] private Camera _playerView;
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnDelay;
    [Header("Prefab")]
    [SerializeField] private BackScreamer _template;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
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
        }
    }
}
