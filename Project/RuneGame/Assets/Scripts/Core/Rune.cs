using UnityEngine;
using Dariyal.Runes.Enumerations;


namespace Dariyal.Runes.Core
{
    /// <summary>
    /// Rune base class.
    /// </summary>
    public class Rune : MonoBehaviour
    {
        #region Properties and Members

        /// <summary>
        /// 
        /// </summary>
        public BonusType Bonus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        #endregion

        #region Contructors

        /// <summary>
        /// 
        /// </summary>
        public Rune()
        {
            Bonus = BonusType.None;
        }

        #endregion

        #region Unity Lifecycle

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// check if a rune is of the same type as this.
        /// </summary>
        /// <param name="otherRune"></param>
        /// <returns></returns>
        public bool IsSameType(Rune otherRune)
        {
            if ((otherRune == null) || !(otherRune is Rune))
                throw new System.ArgumentException("otherRune");

            return string.Compare(Type, (otherRune as Rune).Type) == 0;
        }

        /// <summary>
        /// assign the rune.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Assign(string type, int row, int column)
        {
            if (string.IsNullOrEmpty(type))
                throw new System.ArgumentException("type");

            Column = column;
            Row = row;
            Type = type;
        }

        /// <summary>
        /// swap position of runes.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void SwapColumnRow(Rune a, Rune b)
        {
            int temp = a.Row;
            a.Row = b.Row;
            b.Row = temp;

            temp = a.Column;
            a.Column = b.Column;
            b.Column = temp;
        }

        #endregion

    }
}