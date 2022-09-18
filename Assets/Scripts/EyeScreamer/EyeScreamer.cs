using DG.Tweening;
using UnityEngine;

public class EyeScreamer : MonoBehaviour
{
    private const float Offset = 40;

    public void Init(Transform player)
    {
        transform.rotation = Quaternion.LookRotation(player.forward, Vector3.up);

        var direction = Random.Range(0, 2) == 0 ? -1 : 1;
        var startPosition = transform.position + transform.right * direction * Offset;
        var endPosition = transform.position - transform.right * direction * Offset;

        transform.localScale = Vector3.zero;
        transform.position = startPosition;

        transform.DOScale(1f, 1f);
        transform.DOShakeRotation(3f);
        transform.DOMove(endPosition, 3f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOScale(0f, 0.5f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        });
    }
}
