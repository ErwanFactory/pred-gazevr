using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GazeVR
{
    public class PrimitiveTypeGazeRenderer : GazeRenderer
    {
        public override void RenderGaze()
        {
            transform.position = gaze.cam_position;
            transform.Rotate(gaze.gaze_orientation);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}