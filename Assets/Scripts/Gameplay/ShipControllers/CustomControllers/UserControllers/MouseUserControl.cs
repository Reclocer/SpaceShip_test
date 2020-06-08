using UnityEngine;

namespace Gameplay.ShipControllers
{
    public class MouseUserControl : MonoBehaviour, IUserControl
    {
        private float _x;
        /// <summary>
        /// GetAxis("Horizontal")
        /// </summary>
        public float X => _x;

        private bool _key;
        /// <summary>
        /// GetKey(KeyCode)
        /// </summary>
        public bool Key => _key;

        public Object Object => this;

        void Update()
        {
            _x = Input.GetAxis("Mouse X");            
            _key = Input.GetMouseButton(0);
        }

        public Object GetObject()
        {
            return this;
        }
    }
}

