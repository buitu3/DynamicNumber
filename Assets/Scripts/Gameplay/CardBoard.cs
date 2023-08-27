using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicNumber.GamePlay
{
    public class CardBoard : MonoBehaviour
    {
        [SerializeField]
        private EffectCard CardPrefab;

        private void Start()
        {
            InitBoard();
        }

        private void InitBoard()
        {
            var offset = new Vector2(Constant.BOARD_OFFSET_X, Constant.BOARD_OFFSET_Y);

            for (int yIndex = 0; yIndex < Constant.BOARD_SIZE_HEIGHT; yIndex++)
            {
                for (int xIndex = 0; xIndex < Constant.BOARD_SIZE_WIDTH; xIndex++)
                {
                    var cardPos = new Vector2(xIndex * Constant.CARD_WIDTH_IN_UNIT, yIndex * Constant.CARD_HEIGHT_IN_UNIT);
                    var spacing = new Vector2(xIndex * Constant.BOARD_SPACING_X, yIndex * Constant.BOARD_SPACING_Y);
                    cardPos += (offset + spacing);

                    var card = Instantiate(CardPrefab, this.transform);
                    card.transform.localPosition = cardPos;
                }
            }
        }
    }
}

