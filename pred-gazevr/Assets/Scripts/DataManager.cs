using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GazeVR
{
    [RequireComponent(typeof(ILoader))]
    /** Classe affichant les points de regard
     */
    public class DataManager : MonoBehaviour {

        //Liste des prefabs permettant l'affichage des données oculométriques
        public List<GazeRenderer> gazeRendererPrefabs;
       
        //Classe permettant de charger les données
        private ILoader loader;

        //Interval que l'on affiche
        public float RenderingTimeStart = 0;
        public float RenderingTimeEnd;
        public float RenderingTimeMax;
        //Indique que nous sommes en train de charger les données
        private bool LoadingData;

        //UI
        public Slider TopSlider;
        public Slider BottomSlider;

        public InputField InputMin;
        public InputField InputMax;

        //Liste des données oculométriques
        private List<GameObject> data;
        
        //Scanpath data
        public static bool isFirstPoint = true;
        public static Gaze lastGaze = null;
        public static Vector3 lastHitPoint = new Vector3();

        [Header("Debug")]
        //Affiche la donnée toutes les RenderEvery lignes.
        public int RenderEvery;


        void Start() {
            data = new List<GameObject>();
            //Récupère les données 
            loader = GetComponent<ILoader>();
            //Permet d'éviter le blocage lors du chargement (la personne est déjà dans la pièce et les données se chargent autour d'elle)
            LoadingData = true;
            StartCoroutine(loader.ReadData(this, RenderEvery));
            InputMin.text = "0";
        }

        void Update() {
        }

        //Fonction qui permet d'afficher un point de regard
        public void RenderGaze(Gaze gaze, Transform parent)
        {

            if (gaze.TimeStamp > RenderingTimeMax)
            {
                RenderingTimeMax = gaze.TimeStamp;
                BottomSlider.maxValue = RenderingTimeMax;
                TopSlider.maxValue = RenderingTimeMax;
            }
            if (LoadingData)
            {
                RenderingTimeEnd = RenderingTimeMax;
                BottomSlider.value = RenderingTimeEnd;
                LoadingData = true;
            }

            foreach (var gazeRenderer in gazeRendererPrefabs)
            {
                GazeRenderer render = Instantiate<GazeRenderer>(gazeRenderer, parent);
                render.transform.name = gazeRenderer.name + "#" + gaze.oculoTS;
                render.gaze = gaze;
                render.RenderGaze();
                data.Add(render.gameObject);
                render.gameObject.SetActive(render.gaze.TimeStamp >= RenderingTimeStart && render.gaze.TimeStamp <= RenderingTimeEnd);
            }
        }

        public void FilterData()
        {
            data.ForEach(g => {
                if (g != null)
                {
                    g.SetActive(g.GetComponent<GazeRenderer>().gaze.TimeStamp >= RenderingTimeStart && g.GetComponent<GazeRenderer>().gaze.TimeStamp <= RenderingTimeEnd);
                }
                else
                {
                    data.Remove(g);
                }
            });
        }

        public void SlidersOnValueChanged()
        {
            LoadingData = false;
            RenderingTimeStart = Math.Min(BottomSlider.value, TopSlider.value);
            RenderingTimeEnd = Math.Max(BottomSlider.value, TopSlider.value);

            InputMin.text = Convert.ToInt32(Math.Min(BottomSlider.value, TopSlider.value)).ToString();
            InputMax.text = Convert.ToInt32(Math.Max(BottomSlider.value, TopSlider.value)).ToString();

            FilterData();
        }
    }
}