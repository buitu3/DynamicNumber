using Ftech.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DynamicNumber.GamePlay
{
    public class CardQueue : MonoBehaviour
    {
        private Queue<EffectCard> Queue = new Queue<EffectCard>();

        private void Start()
        {
            EventDispatcher.RegisterListener(EventID.ON_CARD_FLIPPED, OnCardUpflipHandler);
        }

        private void OnDestroy()
        {
            EventDispatcher.RemoveListener(EventID.ON_CARD_FLIPPED, OnCardUpflipHandler);
        }

        public bool IsQueueFull()
        {
            return Queue.Count >= Constant.CARD_QUEUE_SIZE;
        }

        #region Event Handlers

        private void OnCardUpflipHandler(Dictionary<string, object> param)
        {
            var data = param[EventID.EVENT_DATA_KEY];
            if (data is EffectCard)
            {
                var card = data as EffectCard;
                
                Queue.Enqueue(card);
                card.transform.SetParent(this.transform);

                if(IsQueueFull())
                {

                }
            }
        }

        #endregion
    }
}

