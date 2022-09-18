using UnityEngine;
using UnityEngine.Events;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private BackScreamerSpawner _backScreamerSpawner;
    [SerializeField] private EyeScreamerSpawner _eyeScreamerSpawner;
    [SerializeField] private FirstPersonController _firstPersonController;

    public event UnityAction LevelLost;

    private void OnEnable()
    {
        _backScreamerSpawner.Spawned += OnBackScreamerSpawned;
    }

    private void OnDisable()
    {
        _backScreamerSpawner.Spawned -= OnBackScreamerSpawned;
    }

    private void OnBackScreamerSpawned(BackScreamer backScreamer)
    {
        backScreamer.HadSeen += OnHadSeen;
    }

    private void OnHadSeen(BackScreamer screamer)
    {
        screamer.HadSeen -= OnHadSeen;

        _backScreamerSpawner.enabled = false;
        _eyeScreamerSpawner.enabled = false;
        _firstPersonController.enabled = false;

        LevelLost?.Invoke();
    }
}
