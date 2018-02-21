using UnityEngine;

public class NoteView : MonoBehaviour
{
    public NotePitch Pitch;

    public void Move(float distance)
    {
        transform.position += Vector3.back * distance;
    }
}