using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace EdelErde
{
    public class CardFeedbacks : MonoBehaviour
    {
        [SerializeField] MMF_Player heightFeedback;
        [SerializeField] CardVisualTest cardVisualTest;
        [SerializeField] private Transform visualTransform;
        [SerializeField] private GameObject card;
        private Material material;
        [field:SerializeField] public float height { get; private set; }

        private void Start()
        {
            cardVisualTest.onHover += Hover;
            cardVisualTest.onUnhover += Unhover;

            material = card.GetComponent<Renderer>().material;

            heightFeedback.GetFeedbackOfType<MMF_Position>().DestinationPosition = new Vector3(0, height * 0.3f, 0);
            heightFeedback.GetFeedbackOfType<MMF_Scale>().RemapCurveOne = height * 1.2f;
        }

        private void Update()
        {
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            card.GetComponent<Renderer>().GetPropertyBlock(block);
            block.SetVector("_Rotation", new Vector2(visualTransform.localRotation.x, visualTransform.localRotation.y));
            card.GetComponent<Renderer>().SetPropertyBlock(block);
        }

        public void Hover()
        {
            heightFeedback.SetDirection(MMFeedbacks.Directions.TopToBottom);
            heightFeedback.PlayFeedbacks();
        }

        public void Unhover()
        {
            heightFeedback.SetDirection(MMFeedbacks.Directions.BottomToTop);
            heightFeedback.PlayFeedbacks();
            
        }

        private void OnDestroy()
        {
            cardVisualTest.onHover -= Hover;
            cardVisualTest.onUnhover -= Unhover;
        }
    }
}
