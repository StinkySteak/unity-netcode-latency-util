using UnityEngine;

namespace StinkySteak.NetcodeLatency.Gameplay.Player
{
    public class PlayerColor : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Material _materialGreen;
        [SerializeField] private Material _materialYellow;
        [SerializeField] private Material _materialRed;

        public void ApplyColor(bool isLocal, bool isServer, bool isProxy)
        {
            if (isLocal)
            {
                _renderer.material = _materialGreen;
                return;
            }

            if (isServer)
            {
                _renderer.material = _materialYellow;
                return;
            }

            if (isProxy)
            {
                _renderer.material = _materialRed;
                return;
            }
        }
        public void EnableRenderer(bool enableRenderer)
        {
            _renderer.enabled = enableRenderer;
        }
    }
}