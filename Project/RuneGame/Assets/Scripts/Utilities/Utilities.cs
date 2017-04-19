using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Runes
{
    public static class Utilities
    {
        public static IEnumerator AnimatePotentialMatches(IEnumerable<GameObject> potentialMatches)
        {
            for (float i = 1f; i >= 0.3f; i -= 0.1f)
            {
                foreach (var item in potentialMatches)
                {
                    //Do Something
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
    }
}
