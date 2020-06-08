using UnityEngine;

namespace Gameplay.ShipControllers
{
    public class KeyBoardUserControll : MonoBehaviour, IUserControl
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
            _x = Input.GetAxis("Horizontal");
            _key = Input.GetKey(KeyCode.Space);
        }

        public Object GetObject()
        {
            return this;
        }
    }
}