using UnityEngine;

namespace StinkySteak.NetcodeLatency
{
    public interface IVelocityProvider
    {
        Vector3 GetVelocity(Transform transform, float deltaTime);
        void InitDefault();
    }
}