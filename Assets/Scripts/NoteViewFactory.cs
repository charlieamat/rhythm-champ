using System;
using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

public class NoteViewFactory
{
    private readonly GameObject _noteViewPrefab;

    public event EventHandler<NoteViewEventArgs> OnNoteView;

    public NoteViewFactory(GameObject noteViewPrefab)
    {
        _noteViewPrefab = noteViewPrefab;
    }

    public void Create(Note note)
    {
        var noteView = Object.Instantiate(_noteViewPrefab).GetComponent<NoteView>();
        Assert.IsNotNull(noteView);
        noteView.Pitch = note.Pitch;
        OnNoteView?.Invoke(this, new NoteViewEventArgs{NoteView = noteView});
    }
}