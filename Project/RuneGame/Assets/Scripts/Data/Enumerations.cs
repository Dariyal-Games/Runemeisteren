using System;

/// <summary>
/// 
/// </summary>
namespace Dariyal.Runes.Enumerations
{
    /// <summary>
    /// Flags to indicate bonus type.
    /// </summary>
    [Flags]
    public enum BonusType
    {
        None,
        DestroyWholeRowColumn,
        DestroySurrounding,
    }

    /// <summary>
    /// Extension methods to enable easy flag checks
    /// </summary>
    public static class BonusTypeUtilities
    {
        /// <summary>
        /// Check if the bonus type contains Destroy Whole row or column flag.
        /// </summary>
        /// <param name="bt">The bonus type to check.</param>
        /// <returns>Check result.</returns>
        public static bool ContainsDestroyWholeRowColumn(BonusType bt)
        {
            return (bt & BonusType.DestroyWholeRowColumn) == BonusType.DestroyWholeRowColumn;
        }

        /// <summary>
        /// Check if the bonus type contains Destroy surrounding flag.
        /// </summary>
        /// <param name="bt">The bonus type to check.</param>
        /// <returns>Check result.</returns>
        public static bool ContainsDestroySurrounding(BonusType bt)
        {
            return (bt & BonusType.DestroySurrounding) == BonusType.DestroySurrounding;
        }
    }

    /// <summary>
    /// States in the game.
    /// </summary>
    public enum GameState
    {
        None,
        SelectionStarted,
        Animating,
    }
}
