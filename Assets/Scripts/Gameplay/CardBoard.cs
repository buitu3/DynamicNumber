using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DynamicNumber.GamePlay
{
    public class CardBoard : MonoBehaviour
    {
        [SerializeField]
        private RectTransform CardContainer;
        
        [SerializeField]
        private ValueCard ValueCardPrefab;

        [SerializeField] private EffectCard SpecialCardPrefab;

        private RectTransform CardPrefabRect;
        private Vector2 BoardStartPos;

        private int OffSetX = 8;
        private int OffSetY = 8;

        private void Start()
        {
            CardPrefabRect = ValueCardPrefab.GetComponent<RectTransform>();

            // Calculate board start position
            var boardCenter = Camera.main.WorldToScreenPoint(CardContainer.position);
            BoardStartPos = new Vector2(boardCenter.x - CardContainer.rect.width/2, boardCenter.y - CardContainer.rect.height/2);

            InitBoard();
        }

        private void InitBoard()
        {
            var cardCount = Constant.BOARD_SIZE_HEIGHT * Constant.BOARD_SIZE_WIDTH;
            
            var valueCardCount = cardCount * Constant.VALUE_CARD_PERCENTAGE;
            var specialCardCount = cardCount - valueCardCount;
            
            for (int yIndex = 0; yIndex < Constant.BOARD_SIZE_HEIGHT; yIndex++)
            {
                for (int xIndex = 0; xIndex < Constant.BOARD_SIZE_WIDTH; xIndex++)
                {
                    var newCard = Instantiate(ValueCardPrefab, CardContainer.transform);

                    // Generate Value card properties randomly
                    var valueType = (ValueCardType) Random.Range(0, System.Enum.GetValues(typeof(ValueCardType)).Length);
                    var valueAmount = Random.Range(Constant.VALUE_CARD_RANGE_MIN, Constant.VALUE_CARD_RANGE_MAX + 1);
                    newCard.SetContent(valueType, valueAmount);

                    var cardPos = Camera.main.ScreenToWorldPoint(CalculateCardPos(xIndex, yIndex));
                    newCard.transform.position = new Vector3(cardPos.x, cardPos.y, 0);
                }
            }
        }

        private Vector2 CalculateCardPos(int xIndex, int yIndex)
        {
            var result = Vector2.zero;

            var cardWidth = CardPrefabRect.rect.width;
            var cardHeight = CardPrefabRect.rect.height;

            result.x = BoardStartPos.x + xIndex * cardWidth + xIndex * OffSetX + cardWidth/2;
            result.y = BoardStartPos.y + yIndex * cardHeight + yIndex * OffSetY + cardHeight/2;

            return result;
        }
    }
}

