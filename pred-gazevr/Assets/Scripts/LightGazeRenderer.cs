using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GazeVR
{
    [RequireComponent(typeof(Light))]
    public class LightGazeRenderer : GazeRenderer
    {
        public Light gazeLight;
        // Use this for initialization
        void Start()
        {
            gazeLight = GetComponent<Light>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void RenderGaze()
        {
            gazeLight.transform.position = gaze.cam_position;
            gazeLight.transform.Rotate(gaze.gaze_orientation);
        }
    }
}