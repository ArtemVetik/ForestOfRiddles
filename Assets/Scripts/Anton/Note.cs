using UnityEngine;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _id;

    public event UnityAction<int, Sprite> Collected;

    public int ID => _id;

    private void Start()
    {
        _spriteRenderer.sprite = _sprite;
    }

    public void SetID(int id)
    {
        _id = id;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Collected?.Invoke(_id, _sprite);
            Destroy(_gameObject);
        }
    }
}
