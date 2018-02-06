using UnityEngine;

public class MusicBehavior : MonoBehaviour {

	private void Start()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
