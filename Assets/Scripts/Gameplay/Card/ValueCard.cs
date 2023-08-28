using System.Collections;
using System.Collections.Generic;
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
        }

        public override void SetCardDown()
        {
            if (ValueText) ValueText.gameObject.SetActive(false);
            base.SetCardDown();
        }

        public override void UpFlip()
        {
            base.UpFlip();
        }

        public override void ShowContent()
        {
            if (ValueText)
            {
                ValueText.gameObject.SetActive(true);
            }
            base.ShowContent();
        }
    }
}

