using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Magazine _magazine;

    private string _string = "Notes ";
    private int _countNote;
    private int _count = 0;

    private void OnEnable()
    {
        _magazine.ChangedCountNotes += OnSetCountNotes;
    }

    private void OnDisable()
    {
        _magazine.ChangedCountNotes -= OnSetCountNotes;
    }

    private void Start()
    {
        _countNote = _magazine.CountNotes;
        _lable.text = _string + 0 + "/" + _countNote;
    }

    private void OnSetCountNotes()
    {
        _count += 1;
        _lable.text = _string + _count + "/" + _countNote;
    }
}
