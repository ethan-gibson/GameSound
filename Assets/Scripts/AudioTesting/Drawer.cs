using System.Linq.Expressions;
using UnityEngine;

public class Drawer : MonoBehaviour, IInteractable
{
	[field: SerializeField] public float MaxRange { get; set; }
	[field: SerializeField] public string InteractionText { get; set; }

	[SerializeField] private GameObject drawer;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip openDrawer;
	[SerializeField] private AudioClip closeDrawer;

	private bool isOpen;

	public void OnHover()
	{
		HudManager.Instance.SetInteractionText(InteractionText);
	}

	public void Interact()
	{
		switch (isOpen)
		{
			case false:
				audioSource.PlayOneShot(openDrawer);
				isOpen = true;
				drawer.transform.localPosition -= new Vector3(0, 0, 0.84f);
				break;
			case true:
				audioSource.PlayOneShot(closeDrawer);
				isOpen = false;
				drawer.transform.localPosition += new Vector3(0, 0, 0.84f);
				break;
		}
	}

	public void EndHover()
	{
		HudManager.Instance.SetInteractionText("");
	}
}