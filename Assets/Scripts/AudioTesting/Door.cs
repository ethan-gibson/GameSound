using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; }
	[field: SerializeField] public string InteractionText { get; set; }

	private bool isOpen = false;
	private float startRot;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip openSound;
	[SerializeField] private AudioClip closeSound;

	public void OnHover()
	{
		HudManager.Instance.SetInteractionText(InteractionText);
	}

	public void Interact()
	{
		float _newYRot = isOpen ? startRot : startRot - 90;
		transform.localRotation = Quaternion.Euler(0f, _newYRot, 0f);
		isOpen = !isOpen;

		audioSource.Stop();
		if (isOpen)
		{
			//closing door
			audioSource.PlayOneShot(openSound);
		}
		else
		{
			//opening door
			audioSource.PlayOneShot(closeSound);
		}
	}

	public void EndHover()
	{
		HudManager.Instance.SetInteractionText("");
	}
}