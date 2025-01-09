using System;
using UnityEngine;

namespace EdelErde
{
    public class CardVisualTest : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        public Action onHover;
        public Action onUnhover;

        private bool isHovered;

        private void OnMouseOver()
        {
            if (isHovered) return;
            Hover();
        }

        private void OnMouseExit()
        {
            Unhover();
        }

        private void Hover()
        {
            onHover?.Invoke();
            isHovered = true;
        }

        private void Unhover()
        {
            onUnhover?.Invoke();
            isHovered = false;
        }
    }
}
