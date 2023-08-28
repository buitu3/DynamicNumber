using System.Collections;
using System.Collections.Generic;
using Ftech.Utilities;
using UnityEngine;
using TMPro;

namespace DynamicNumber.GamePlay 
{
    public enum ValueCardType
    {
        multiply = 0,
        divide
    }

    public class ValueCard : EffectCard
    {
        [SerializeField]
        private TextMeshProUGUI ValueText;

        private ValueCardType ValueType;
        private int ValueAmount;

        public void SetContent(ValueCardType type, int amount)
        {
            switch (type) 
            {
                case ValueCardType.multiply:
                    {
                        ValueText.text = "X" + amount;
                        break;
                    }
                case ValueCardType.divide:
                    {
                        ValueText.text = 1 + "/" + amount;
                        break;
                    }
            }

            ValueType = type;
            ValueAmount = amount;
        }

        public override void SetCardDown()
        {
            if (ValueText) ValueText.gameObject.SetActive(false);
            base.SetCardDown();
        }

        public override void ShowContent()
        {
            if (ValueText)
            {
                ValueText.gameObject.SetActive(true);
            }
            base.ShowContent();
        }

        public override void ActiveEffect()
        {
            var playerPoint = GameManager.Instance.PlayerCurrentValue;
            
            switch (ValueType)
            {
                case ValueCardType.multiply:
                {
                    playerPoint *= ValueAmount;
                    break;
                }
                case ValueCardType.divide:
                {
                    playerPoint /= ValueAmount;
                    break;
                }
            }
            
            var message = new Dictionary<string, object>();
            message.Add(EventID.EVENT_DATA_KEY, playerPoint);
            EventDispatcher.PostEvent(EventID.ON_PLAYER_POINT_CHANGE, message);

            Destroy(this.gameObject);
        }
    }
}

