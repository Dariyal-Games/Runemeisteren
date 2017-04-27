using Dariyal.Runes.Enumerations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dariyal.Runes.Core
{
    public class MatchesInfo
    {
        private List<GameObject> matchedRunes;

        public BonusType BonusesContained { get; set; }

        public IEnumerable<GameObject> MatchedRune
        {
            get { return matchedRunes.Distinct(); }
        }

        public void AddObject(GameObject go)
        {
            if (!matchedRunes.Contains(go))
                matchedRunes.Add(go);
        }

        public void AddObjectRange(IEnumerable<GameObject> gos)
        {
            foreach (var item in gos)
            {
                AddObject(item);
            }
        }

        public MatchesInfo()
        {
            matchedRunes = new List<GameObject>();
            BonusesContained = BonusType.None;
        }
    }
}
