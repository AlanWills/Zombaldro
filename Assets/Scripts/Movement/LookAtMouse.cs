using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Zombaldro.Movement
{
    [AddComponentMenu("Zombaldro/Movement/Look At Mouse")]
    public class LookAtMouse : MonoBehaviour
    {
        #region Unity Methods

        public void Update()
        {
            Vector3 screenPosition = UnityEngine.Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Vector3 mousePosition = Input.mousePosition;
            Vector3 delta = mousePosition - screenPosition;

            if (delta.sqrMagnitude >= 1)
            {
                float angleRad = Mathf.Atan2(-delta.x, delta.y);
                float angleDeg = (180 / Mathf.PI) * angleRad;

                transform.rotation = Quaternion.Euler(0, 0, angleDeg); 
            }
        }

        #endregion
    }
}