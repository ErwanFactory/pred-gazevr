using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GazeVR
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleGazeRenderer : GazeRenderer
    {
        public new ParticleSystem particleSystem;
        private ParticleSystem.Particle[] particlesArray;

        // Use this for initialization
        void Start()
        {
            Global.particleNumber++;
            particleSystem = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public override void RenderGaze()
        {            
            transform.position = gaze.cam_position;
            RaycastHit hit;
            if (Physics.Raycast(gaze.cam_position, gaze.gaze_orientation, out hit))
            {
                particlesArray = new ParticleSystem.Particle[1];
                particlesArray[0].position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                particleSystem.transform.position = hit.point;

                particleSystem.SetParticles(particlesArray, particlesArray.Length);
                particleSystem.Play();
            }
            else
            {
                print("no hit");
                Destroy(this.gameObject);
            }
        }
    }
}
