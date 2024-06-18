namespace StinkySteak.NetcodeLatency
{
    public static class MovementTypeConstructor
    {
        public static IVelocityProvider GetVelocityProvider(MovementType movementType)
        {
            IVelocityProvider velocityProvider = null;

            switch (movementType)
            {
                case MovementType.Linear:
                    velocityProvider = new LinearMovement();
                    break;
                case MovementType.Rectangle:
                    velocityProvider = new RectangleMovement();
                    break;
            }

            return velocityProvider;
        }
    }
}