using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    [SerializeField] private GameObject _magazine;
    [SerializeField] private List<Note> _notes;
    [SerializeField] private List<ImageNote> _images;

    private bool _open = false;

    public int CountNotes => _notes.Count;

    public event UnityAction Won;
    public event UnityAction ChangedCountNotes;

    private void OnEnable()
    {
        foreach (var note in _notes)
            note.Collected += OnCollect;
    }

    private void OnDisable()
    {
        foreach (var note in _notes)
            note.Collected -= OnCollect;
    }

    private void Start()
    {
        for (int i = 0; i < _notes.Count; i++)
        {
            _notes[i].SetID(i);
            _images[i].SetID(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            Open();
    }

    private void Open()
    {
        if (_open == false)
        {
            _open = true;
            _magazine.SetActive(true);
        }
        else
        {
            _open = false;
            _magazine.SetActive(false);
        }
    }

    private void OnCollect(int id, Sprite sprite)
    {
        for (int i = 0; i < _images.Count; i++)
            if (_images[i].ID == id)
                _images[i].SetNote(sprite);


        for (int i = 0; i < _notes.Count; i++)
            if (_notes[i].ID == id)
            {
                _notes[i].Collected -= OnCollect;
                _notes.RemoveAt(i);
            }

        ChangedCountNotes?.Invoke();

        if (_notes.Count == 0)
            Won?.Invoke();
    }
}
