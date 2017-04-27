using Dariyal.Runes.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Runes
{
    public static class Utilities
    {
        /// <summary>
        /// Animate the potential matches.
        /// </summary>
        /// <param name="potentialMatches"></param>
        /// <returns></returns>
        public static IEnumerator AnimatePotentialMatches(IEnumerable<GameObject> potentialMatches)
        {
            for (float i = 1f; i >= 0.3f; i -= 0.1f)
            {
                foreach (var item in potentialMatches)
                {
                    //Do Something
                    Color c = item.GetComponent<SpriteRenderer>().color;
                    c.a = i;
                    item.GetComponent<SpriteRenderer>().color = c;
                }
                yield return new WaitForSeconds(Constants.OpacityAnimationFrameDelay);
            }

            for (float i = 0.3f; i <= 1f; i += 0.1f)
            {
                foreach (var item in potentialMatches)
                {
                    Color c = item.GetComponent<SpriteRenderer>().color;
                    c.a = i;
                    item.GetComponent<SpriteRenderer>().color = c;
                }
                yield return new WaitForSeconds(Constants.OpacityAnimationFrameDelay);
            }
        }

        /// <summary>
        /// Check if neighbours.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool AreVerticalOrHorizontalNeighbours(Rune a, Rune b)
        {
            return (a.Column == b.Column || a.Row == b.Row && Mathf.Abs(a.Column - b.Column) <= 1 && Mathf.Abs(a.Row - b.Row) <= 1);
        }

        /// <summary>
        /// Get a random match.
        /// </summary>
        /// <param name="runes"></param>
        /// <returns></returns>
        public static IEnumerable<GameObject> GetPotentialMatches(RunesArray runes)
        {
            List<List<GameObject>> matches = new List<List<GameObject>>();
            for (int row = 0; row < Constants.Rows; row++)
            {
                for (int column = 0; column < Constants.Columns; column++)
                {
                    //Check for matches and add to the matches variable.
                }
            }

            return null;
        }
    }
}
