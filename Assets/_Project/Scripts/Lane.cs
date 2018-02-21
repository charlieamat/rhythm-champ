using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public NotePitch Pitch;

    private List<NoteView> _noteViews = new List<NoteView>();

    public void Add(NoteView noteView)
    {
        _noteViews.Add(noteView);
    }

    public void Increment(float deltaTime, float offset)
    {
        _noteViews.ForEach(n => n.Move(deltaTime * offset));
    }
}