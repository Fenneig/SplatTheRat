using SplatTheRat.Components.Interfaces;
using UnityEngine;

namespace SplatTheRat.Systems
{
    public class InputHandler : MonoBehaviour
    {
        private Camera _mainCamera;
        

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;
            
            if (hit.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage();
            }
        }
    }
}