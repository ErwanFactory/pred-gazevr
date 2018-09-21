using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GazeVR { 
    /** Classe représentant les données oculométriques : Peut sûrement être optimisée
     * 
     * 
     */
    public class Gaze
    {
        public string UserID { get; private set; }

        //Données temporelles
        public ulong TimeStamp { get { return oculoTS / 1000000000;  } }
        public ulong oculoTS { get; private set; }
        public ulong unityTS { get; private set; }
        public ulong currFrame { get; private set; }

        //Données spatiales
        [Obsolete("Utilisez plutôt gaze_orientation, il semblerait que cette donnée prenne aussi l'orientation du casque.")]
        public Vector3 orientation { get { return gaze_orientation + cam_orientation; } }

        public Vector3 gaze_orientation { get; private set; }
        public Vector3 cam_orientation { get; private set; }
        public Vector3 cam_position { get; private set; }

        public Gaze(string userID, ulong oculoTS, ulong unityTS, ulong currFrame, Vector3 gaze_orientation, Vector3 cam_orientation, Vector3 cam_position)
        {
            this.UserID = userID;
            this.oculoTS = oculoTS;
            this.unityTS = unityTS;
            this.currFrame = currFrame;

            this.gaze_orientation = gaze_orientation;
            this.cam_orientation = cam_orientation;
            this.cam_position = cam_position;
        }

    }
}
