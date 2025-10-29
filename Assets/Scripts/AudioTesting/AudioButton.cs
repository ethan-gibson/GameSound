using UnityEngine;

public class AudioButton : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; }
	[field: SerializeField] public string InteractionText { get; set; }
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip audioClip;
	private bool isPlaying;

	public void OnHover()
	{
		HudManager.Instance.SetInteractionText(InteractionText);
	}

	public void Interact()
	{
		switch (isPlaying)
		{
			case false:
				audioSource.PlayOneShot(audioClip);
				isPlaying = true;
				break;
			case true:
				audioSource.Stop();
				isPlaying = false;
				break;
		}
	}

	public void EndHover()
	{
		HudManager.Instance.SetInteractionText("");
	}
}