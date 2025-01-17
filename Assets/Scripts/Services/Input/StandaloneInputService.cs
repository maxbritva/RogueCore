using UnityEngine;

namespace Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                var axis = SimpleInputAxis();
                if (axis == Vector2.zero)
                    axis = UnityInputAxis();
                return axis;
            }
        }
        private Vector2 UnityInputAxis() => 
            new Vector2(UnityEngine.Input.GetAxis(Horizontal), 
                UnityEngine.Input.GetAxis(Horizontal));
    }
}