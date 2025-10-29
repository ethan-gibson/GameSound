using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
	[SerializeField] private AudioClip hoverSound;
	[SerializeField] private AudioClip clickSound;
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		audioSource.PlayOneShot(hoverSound);
		Debug.Log("OnPointerEnter");
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		audioSource.PlayOneShot(clickSound);
	}
}
