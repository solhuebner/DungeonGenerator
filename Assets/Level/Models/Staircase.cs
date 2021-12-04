using Assets.World.Models;
using UnityEngine;

namespace Assets.Level.Models
{
    public class Staircase : LevelComponent
    {

        public Vector3Int Previous { get; }
        public Vector3Int VerticalOffset { get; }
        public Vector3Int HorizontalOffset { get; }
        public bool IsUp { get; }
        public Direction Direction { get; }

        public Staircase(Vector3Int previous, Vector3Int verticalOffset, Vector3Int horizontalOffset) : base()
        {
            AddPieces(previous, verticalOffset, horizontalOffset);

            var isUp = verticalOffset.y > 0;
            var direction = horizontalOffset.x == 0 ? horizontalOffset.z > 0 ? Direction.North : Direction.South
                                                    : horizontalOffset.x > 0 ? Direction.East : Direction.West;

            Previous = previous;
            VerticalOffset = verticalOffset;
            HorizontalOffset = horizontalOffset;

            IsUp = isUp;
            Direction = direction;
        }

        private void AddPieces(Vector3Int previous, Vector3Int verticalOffset, Vector3Int horizontalOffset)
        {
            var first = new LevelComponentPiece(Id, previous + horizontalOffset, previous + horizontalOffset * 2);
            var second = new LevelComponentPiece(Id, previous + horizontalOffset * 2, previous + verticalOffset + horizontalOffset, ref first);
            var third = new LevelComponentPiece(Id, previous + verticalOffset + horizontalOffset, previous + verticalOffset + horizontalOffset * 2, ref second);
            var fourth = new LevelComponentPiece(Id, previous + verticalOffset + horizontalOffset * 2, null, ref third);

            AddPiece(first);
            AddPiece(second);
            AddPiece(third);
            AddPiece(fourth);
        }

        public Staircase(Vector3Int fromDirection, Vector3Int toDirection)
        {

        }
    }
}