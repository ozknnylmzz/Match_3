using System.Collections.Generic;

namespace Match3
{
    public class HorizontalMatchDetector : MatchDetector
    {
        private readonly GridPosition[] _lookUpDirections;

        public override MatchDetectorType MatchDetectorType => MatchDetectorType.Horizontal;

        public HorizontalMatchDetector()
        {
            _lookUpDirections = new[] { GridPosition.Left, GridPosition.Right };
        }

        public override MatchSequence GetMatchSequence(IBoard board, GridPosition initialPosition)
        {
            IGridSlot initialSlot = board[initialPosition];
            List<IGridSlot> matchedGridSlots = new List<IGridSlot> { initialSlot };

            foreach (GridPosition direction in _lookUpDirections)
            {
                GridPosition newPosition = initialPosition + direction;

                while (IsMatchAvailable(board, newPosition, initialSlot, out IGridSlot matchSlot))
                {
                    newPosition += direction;
                    matchedGridSlots.Add(matchSlot);
                }
            }

            if (IsEnoughMatch(matchedGridSlots))
            {
                return new MatchSequence(matchedGridSlots, MatchDetectorType);
            }

            return null;
        }
    } 
}