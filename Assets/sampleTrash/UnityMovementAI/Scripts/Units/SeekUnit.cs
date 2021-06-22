using UnityEngine;
using System.Collections;

namespace UnityMovementAI
{
    public class SeekUnit : MonoBehaviour
    {
        public Transform target;

        SteeringBasics steeringBasics;

        void Start()
        {
            target = GameObject.Find("VR rig").transform;
            steeringBasics = GetComponent<SteeringBasics>();
        }

        void FixedUpdate()
        {
            Vector3 accel = steeringBasics.Seek(target.position);

            steeringBasics.Steer(accel);
            steeringBasics.LookWhereYoureGoing();
        }
    }
}