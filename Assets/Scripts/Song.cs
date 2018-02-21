using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Song : ScriptableObject
{
    public AudioClip AudioClip;
    public float StartDelay;
    public float Tempo;
    public List<Note> Notes;
}