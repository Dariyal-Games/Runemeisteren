using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dariyal.Runes.Core
{
    public class AlteredRuneInfo
    {
        private List<GameObject> newRune;
        public int MaxDistance { get; set; }

        public IEnumerable<GameObject> AlteredRune
        {
            get { return newRune.Distinct(); }
        }

        public void AddRune(GameObject go)
        {
            if (!newRune.Contains(go))
                newRune.Add(go);
        }

        public AlteredRuneInfo()
        {
            newRune = new List<GameObject>(); 
        }
    }
}
