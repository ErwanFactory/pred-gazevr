using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using System.Globalization;

namespace GazeVR
{
    /** Implémentation de l'interface Loader pour le format CSV
     * 
     */
    public class CSVLoader : MonoBehaviour, ILoader
    {
        void Start() {
        }
        
        public IEnumerator ReadData(DataManager dm, int precision)
        {
            //Récupère tous les fichiers dans le dossier Data/
            var di = new DirectoryInfo(Application.dataPath + "/Data/");
            if (di.Exists)
            {
                foreach (var file in di.GetFiles())
                {
                    //Il traite les fichiers CSV
                    if (file.Extension == ".csv")
                    {
                        GameObject parent = new GameObject(file.Name);
                        using (var reader = file.OpenText())
                        {
                            int count = 0;
                            bool notfirstLine = false;
                            ulong startTimeValue = 0;
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                if (notfirstLine && count++ >= precision)
                                {
                                    try
                                    {
                                        var values = line.Split(',');

                                        if (startTimeValue == 0)
                                        {
                                            startTimeValue = Convert.ToUInt64(values[0]);
                                        }

                                        Gaze gaze = new Gaze(file.Name, Convert.ToUInt64(values[0]) - startTimeValue, Convert.ToUInt64(values[1]), Convert.ToUInt64(values[2]),
                                            new Vector3(float.Parse(values[3], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[4], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[5], CultureInfo.InvariantCulture.NumberFormat)),
                                            new Vector3(float.Parse(values[6], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[7], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[8], CultureInfo.InvariantCulture.NumberFormat)),
                                            new Vector3(float.Parse(values[9], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[10], CultureInfo.InvariantCulture.NumberFormat), float.Parse(values[11], CultureInfo.InvariantCulture.NumberFormat)));
                                        dm.RenderGaze(gaze, parent.transform);
                                        count = 0;
                                    }
                                    catch { }
                                    yield return null;
                                }
                                else
                                {
                                    notfirstLine = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                print("Directory '" + di.ToString() + "' not found");
            }
        }

    }
}