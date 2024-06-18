using UnityEngine;

namespace StinkySteak.NetcodeLatency
{
    public class LinearMovement : IVelocityProvider
    {
        private Vector3 _startPosition;
        private Vector3 _endPosition;

        private float _alpha;
        private float _moveSpeed;
        private float _forward;

        public void InitDefault()
        {
            float extents = 10;

            _startPosition = new Vector3(-1, 0, 0) * extents;
            _endPosition = new Vector3(1, 0, 0) * extents;
            _moveSpeed = 0.5f;
        }

        public void Init(Vector2 startPos, Vector2 endPos)
        {
            _startPosition = startPos;
            _endPosition = endPos;
        }

        public Vector3 GetVelocity(Transform transform, float deltaTime)
        {
            float speed = deltaTime * _moveSpeed;
            _alpha += speed * _forward;

            Vector3 targetPos = Vector3.Lerp(_startPosition, _endPosition, _alpha);

            Vector3 velocity = targetPos - transform.position;

            if (_alpha > 1)
                _forward = -1;

            if (_alpha <= 0)
                _forward = 1;

            return velocity;
        }
    }
}