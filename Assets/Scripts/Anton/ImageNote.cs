using UnityEngine;
using UnityEngine.UI;

public class ImageNote : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _color;

    private int _id;

    public int ID => _id;

    public void SetID(int id)
    {
        _id = id;
    }

    public void SetNote(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.color = _color;
    }
}
