using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GazeVR
{
    [RequireComponent(typeof(LineRenderer))]
    public class ScanPathGazeRenderer : GazeRenderer
    {
        public float startWidth;
        public float endWidth;
        public Vector3 hitPoint = new Vector3();

        public Material Material;

        public LineRenderer gazeScanPath;
        // Use this for initialization
        void Start()
        {
            gazeScanPath = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {

        }


        public override void RenderGaze()
        {

            if (DataManager.isFirstPoint == true)
            {
                DataManager.isFirstPoint = false;
            }

            else
            {
                //transform.position = gaze.cam_position;
                RaycastHit hit;
                if (Physics.Raycast(gaze.cam_position, gaze.gaze_orientation, out hit))
                {
                    hitPoint = hit.point;

                    gazeScanPath.SetPosition(0, DataManager.lastHitPoint);
                    gazeScanPath.SetPosition(1, hitPoint);

                }
                else
                {
                    print("no hit");
                    Destroy(this.gameObject);
                }
            }
            DataManager.lastGaze = gaze;
            DataManager.lastHitPoint = hitPoint;
        }


    }
}