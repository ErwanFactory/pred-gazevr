using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GazeVR
{
    public class VectorGazeRenderer : GazeRenderer
    {
        public float startWidth;
        public float endWidth;

        public Material Material;

        public override void RenderGaze()
        {
            //transform.position = gaze.cam_position;
            RaycastHit hit;
            Vector3 orientation = gaze.gaze_orientation;
            if (Physics.Raycast(gaze.cam_position, orientation, out hit))
            {
                var lr = this.gameObject.AddComponent<LineRenderer>();
                lr.startWidth = startWidth;
                lr.endWidth = endWidth;
                lr.SetPosition(0, gaze.cam_position);
                lr.SetPosition(1, hit.point);

                lr.material = Material;
                lr.material.color = UnityEngine.Random.ColorHSV();

            }
            else
            {
                print("no hit");
                Destroy(this.gameObject);
            }
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