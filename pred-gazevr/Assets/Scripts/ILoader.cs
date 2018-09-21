using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GazeVR
{
    /** Interface qui charge les données d'oculométries
     * 
     */
    public interface ILoader
    {
        IEnumerator ReadData(DataManager dm, int precision);
    }
}
