using System.Collections.Generic;
using UnityEngine;

public class LaneManager
{
    private readonly List<Lane> _lanes;

    public LaneManager(List<Lane> lanes)
    {
        _lanes = lanes;
    }

    public void Add(NoteView noteView)
    {
        var lane = _lanes.Find(l => l.Pitch == noteView.Pitch);

        if (lane != null)
        {
            lane.Add(noteView);
            noteView.transform.SetParent(lane.transform, false);
        }
        else
        {
            Debug.LogWarning($"Failed to add note to LaneManager. No lane for pitch {noteView.Pitch} found");
        }
    }

    public void Increment(float deltaTime, float tempo)
    {
        _lanes?.ForEach(l => l.Increment(deltaTime, tempo/60));
    }
}