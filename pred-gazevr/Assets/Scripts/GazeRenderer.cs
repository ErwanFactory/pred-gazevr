using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GazeVR
{
    public abstract class GazeRenderer : MonoBehaviour
    {
        public Gaze gaze;

        public abstract void RenderGaze();


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}