using UnityEngine;
	public interface IInteractable
	{
		public float MaxRange {  get; set;  }
		public string InteractionText { get; set; }
		public void OnHover();
		public void Interact();
		public void EndHover();
	}
