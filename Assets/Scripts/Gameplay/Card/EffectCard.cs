using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Ftech.Utilities;

namespace DynamicNumber.GamePlay
{
    public class EffectCard : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image CardIcon;
        [SerializeField]
        private Image CardBG;

        [SerializeField]
        private Sprite DownFlipBG;
        [SerializeField]
        private Sprite UpFlipBG;

        private bool IsUpFlip = false;

        void Awake()
        {
            SetCardDown();
        }        

        public void OnPointerClick(PointerEventData eventData)
        {
            if(!IsUpFlip) UpFlip();
        }        

        public virtual void SetCardDown()
        {
            if(CardIcon) CardIcon.gameObject.SetActive(false);
            CardBG.sprite = DownFlipBG;
        }

        public virtual void UpFlip()
        {
            transform.DOScaleX(0f, Constant.CARD_FLIP_TIME / 2).OnComplete(() =>
            {
                ShowContent();

                transform.DOScaleX(1f, Constant.CARD_FLIP_TIME / 2).OnComplete(() => {
                    var message = new Dictionary<string, object>();
                    message.Add(EventID.EVENT_DATA_KEY, this);
                    EventDispatcher.PostEvent(EventID.ON_CARD_FLIPPED, message);
                });
            });

        }

        public virtual void ShowContent()
        {
            if (CardIcon) CardIcon.gameObject.SetActive(true);
            CardBG.sprite = UpFlipBG;
            IsUpFlip = true;
        }
    }
}
