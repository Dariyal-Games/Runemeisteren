using Dariyal.Runes.Enumerations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dariyal.Runes.Core
{
    public class RunesArray
    {
        #region Members

        private GameObject[,] runes = new GameObject[Constants.Rows, Constants.Columns];
        private GameObject backupG1;
        private GameObject backupG2;

        #endregion

        #region Properties

        public GameObject this[int row, int column]
        {
            get
            {
                try
                {
                    return runes[row, column];
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            set
            {
                runes[row, column] = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Swap 2 game objects.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        public void Swap(GameObject g1, GameObject g2)
        {
            backupG1 = g1;
            backupG2 = g2;

            var g1Rune = g1.GetComponent<Rune>();
            var g2Rune = g2.GetComponent<Rune>();

            int g1Row = g1Rune.Row;
            int g1Column = g1Rune.Column;
            int g2Row = g2Rune.Row;
            int g2Column = g2Rune.Column;

            var temp = runes[g1Row, g1Column];
            runes[g1Row, g1Column] = runes[g2Row, g2Column];
            runes[g2Row, g2Column] = temp;

            Rune.SwapColumnRow(g1Rune, g2Rune);
        }

        /// <summary>
        /// Undo last swap.
        /// </summary>
        public void UndoSwap()
        {
            if (backupG1 == null || backupG2 == null)
                throw new System.Exception("At least one backup is null");

            Swap(backupG1, backupG2);
        }

        /// <summary>
        /// Get the match info.
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public MatchesInfo GetMatches(GameObject go)
        {
            MatchesInfo matchesInfo = new MatchesInfo();

            var horizontalMatches = GetMatchesHorizontally(go);
            if (ContainsDestroyRowColumnBonus(horizontalMatches))
            {
                horizontalMatches = GetEntireRow(go);
                if (!BonusTypeUtilities.ContainsDestroyWholeRowColumn(matchesInfo.BonusesContained))
                    matchesInfo.BonusesContained |= BonusType.DestroyWholeRowColumn;
            }
            matchesInfo.AddObjectRange(horizontalMatches);

            var verticalMatches = GetMatchesVertically(go);
            if (ContainsDestroyRowColumnBonus(verticalMatches))
            {
                verticalMatches = GetEntireColumn(go);
                if (!BonusTypeUtilities.ContainsDestroyWholeRowColumn(matchesInfo.BonusesContained))
                    matchesInfo.BonusesContained |= BonusType.DestroyWholeRowColumn;
            }
            matchesInfo.AddObjectRange(verticalMatches);

            return matchesInfo;
        }

        /// <summary>
        /// Get list of matched gameobjects.
        /// </summary>
        /// <param name="gos"></param>
        /// <returns></returns>
        public IEnumerable<GameObject> GetMatches(IEnumerable<GameObject> gos)
        {
            List<GameObject> matches = new List<GameObject>();
            foreach (var go in gos)
            {
                matches.AddRange(GetMatches(go).MatchedRune);
            }

            return matches;
        }

        public void Remove(GameObject go)
        {
            runes[go.GetComponent<Rune>().Row, go.GetComponent<Rune>().Column] = null;
        }



        #endregion

        #region Private Methods

        /// <summary>
        /// Get all horizontal matches.
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private IEnumerable<GameObject> GetMatchesHorizontally(GameObject go)
        {
            List<GameObject> matches = new List<GameObject>();
            matches.Add(go);
            var rune = go.GetComponent<Rune>();

            if (rune.Column != 0)
            {
                for (int column = rune.Column - 1; column >= 0; column--)
                {
                    if (runes[rune.Row, column] != null && runes[rune.Row, column].GetComponent<Rune>().IsSameType(rune))
                    {
                        matches.Add(runes[rune.Row, column]);
                    }
                    else
                        break;
                }
            }

            if (rune.Column != Constants.Columns - 1)
            {
                for (int column = rune.Column + 1; column < Constants.Columns; column++)
                {
                    if (runes[rune.Row, column] != null && runes[rune.Row, column].GetComponent<Rune>().IsSameType(rune))
                    {
                        matches.Add(runes[rune.Row, column]);
                    }
                    else
                        break;
                }
            }

            if (matches.Count < Constants.MinimumMatches)
                matches.Clear();

            return matches.Distinct();
        }

        /// <summary>
        /// Get all horizontal matches.
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private IEnumerable<GameObject> GetMatchesVertically(GameObject go)
        {
            List<GameObject> matches = new List<GameObject>();
            matches.Add(go);
            var rune = go.GetComponent<Rune>();

            if (rune.Row != 0)
            {
                for (int row = rune.Row - 1; row >= 0; row--)
                {
                    if (runes[row, rune.Column] != null && runes[row, rune.Column].GetComponent<Rune>().IsSameType(rune))
                    {
                        matches.Add(runes[row, rune.Column]);
                    }
                    else
                        break;
                }
            }

            if (rune.Row != Constants.Rows - 1)
            {
                for (int row = rune.Row + 1; row < Constants.Rows; row++)
                {
                    if (runes[row, rune.Column] != null && runes[row, rune.Column].GetComponent<Rune>().IsSameType(rune))
                    {
                        matches.Add(runes[row, rune.Column]);
                    }
                    else
                        break;
                }
            }

            if (matches.Count < Constants.MinimumMatches)
                matches.Clear();

            return matches.Distinct();
        }

        /// <summary>
        /// Get all elements in the row of the given gameobject.
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private IEnumerable<GameObject> GetEntireRow(GameObject go)
        {
            List<GameObject> matches = new List<GameObject>();
            int row = go.GetComponent<Rune>().Row;
            for (int column = 0; column < Constants.Columns; column++)
            {
                matches.Add(runes[row, column]);
            }

            return matches;
        }

        /// <summary>
        /// Get all elements int he column of the geven gameobject.
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        private IEnumerable<GameObject> GetEntireColumn(GameObject go)
        {
            List<GameObject> matches = new List<GameObject>();
            int column = go.GetComponent<Rune>().Column;
            for (int row = 0; row < Constants.Rows; row++)
            {
                matches.Add(runes[row, column]);
            }

            return matches;
        }

        /// <summary>
        /// Check if there is a destroy row or column or both.
        /// </summary>
        /// <param name="matches"></param>
        /// <returns></returns>
        private bool ContainsDestroyRowColumnBonus(IEnumerable<GameObject> matches)
        {
            if (matches.Count() >= Constants.MinimumMatches)
            {
                foreach (var go in matches)
                {
                    if (BonusTypeUtilities.ContainsDestroyWholeRowColumn(go.GetComponent<Rune>().Bonus))
                        return true;
                }
            }

            return false;
        }

        #endregion

    }
}