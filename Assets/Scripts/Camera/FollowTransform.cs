using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Zombaldro.Camera
{
    [AddComponentMenu("Zombaldro/Camera/Follow Transform")]
    public class FollowTransform : MonoBehaviour
    {
        #region Serialized Fields

        public Transform target;

        #endregion

        #region Unity Methods

        public void Update()
        {
            Vector3 targetPosition = target.position;
            Vector3 transformPosition = transform.position;
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transformPosition.z);
        }

        #endregion
    }
}
