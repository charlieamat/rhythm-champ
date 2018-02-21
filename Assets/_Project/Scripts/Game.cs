using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Song _song;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _noteViewPrefab;
    [SerializeField] private List<Lane> _lanes;

    private SongScanner _songScanner;
    private NoteViewFactory _noteViewFactory;
    private LaneManager _laneManager;

    private void Awake()
    {
        _songScanner = new SongScanner(_song);
        _noteViewFactory = new NoteViewFactory(_noteViewPrefab);
        _laneManager = new LaneManager(_lanes);
    }

    private void Start()
    {
        _audioSource.clip = _song.AudioClip;
        _audioSource.PlayDelayed(_song.StartDelay);

        _songScanner.OnNote += (sender, args) => _noteViewFactory.Create(args.Note);
        _noteViewFactory.OnNoteView += (sender, args) => _laneManager.Add(args.NoteView);
    }

    private void FixedUpdate()
    {
        _songScanner.Increment(Time.deltaTime);
        _laneManager.Increment(Time.deltaTime, _song.Tempo);
    }
}