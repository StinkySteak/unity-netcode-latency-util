using UnityEngine;

namespace StinkySteak.NetcodeLatency
{
    public class RectangleMovement : IVelocityProvider
    {
        private Vector3[] _positions;

        private float _alpha;
        private float _moveSpeed;
        private int _toPositionIndex;

        private Vector3 _fromPosition;

        public void InitDefault()
        {
            _moveSpeed = 0.5f;

            int size = 4;

            _positions = new Vector3[size];
            _positions[0] = new Vector3(-1, 0, -1);
            _positions[1] = new Vector3(1, 0, -1);
            _positions[2] = new Vector3(1, 0, 1);
            _positions[3] = new Vector3(-1, 0, 1);

            float multiplier = 10;

            for (int i = 0; i < size; i++)
                _positions[i] *= multiplier;

            _fromPosition = GetFromPosition(1);
            _toPositionIndex = 1;
        }

        public Vector3 GetVelocity(Transform transform, float deltaTime)
        {
            float speed = deltaTime * _moveSpeed;
            _alpha += speed;

            Vector3 nextPos = _positions[_toPositionIndex];
            Vector3 targetPos = Vector3.Lerp(_fromPosition, nextPos, _alpha);

            Vector3 velocity = targetPos - transform.position;

            if (_alpha > 1)
            {
                _alpha = 0;
                _toPositionIndex++;

                _fromPosition = GetFromPosition(_toPositionIndex);

                if (_toPositionIndex >= _positions.Length)
                    _toPositionIndex = 0;
            }

            return velocity;
        }

        private Vector3 GetFromPosition(int toIndex)
        {
            if (toIndex == 0)
                return _positions[^1];

            return _positions[toIndex - 1];
        }
    }
}