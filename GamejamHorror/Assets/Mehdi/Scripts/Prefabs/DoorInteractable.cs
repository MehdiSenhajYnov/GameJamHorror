using UnityEngine;

namespace Mehdi.Scripts.Prefabs
{
    public class DoorInteractable : MonoBehaviour, IInteractable
    {
        public Door door;
        [field:SerializeField] public bool showEButton { get; set; }

        public void Interact()
        {
            door.Interact();
        }
    }
}
