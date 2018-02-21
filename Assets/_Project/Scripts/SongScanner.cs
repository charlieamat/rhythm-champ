using System;
using UnityEngine;

public class SongScanner
{
    private readonly Song _song;

    private float _elapsedTime;

    public event EventHandler<NoteEventArgs> OnNote;

    public SongScanner(Song song)
    {
        _song = song;
    }

    public void Increment(float deltaTime)
    {
        _elapsedTime += deltaTime;

        foreach (var note in _song.Notes)
        {
            var noteTiming = 60 / _song.Tempo * note.Timing;
            if (Mathf.Abs(_elapsedTime - noteTiming) < 0.01f)
            {
                OnNote?.Invoke(this, new NoteEventArgs {Note = note});
            }
        }
    }
}