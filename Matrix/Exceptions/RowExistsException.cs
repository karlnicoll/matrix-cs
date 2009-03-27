using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    /// <summary>
    /// Thrown when an attempt is made to add a row to the matrix when it already exists inside the matrix
    /// </summary>
    public class RowExistsException : ApplicationException
    {
        //==================================================================================
        #region Data Structures



        #endregion

        //==================================================================================
        #region Enumerations



        #endregion

        //==================================================================================
        #region Constants


        #endregion

        //==================================================================================
        #region Events



        #endregion

        //==================================================================================
        #region Private Variables


        #endregion

        //==================================================================================
        #region Constructors/Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RowExistsException()
            : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The message to describe what has happened</param>
        public RowExistsException(string Message)
            : base(Message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The message to describe what has happened</param>
        /// <param name="InnerException">The exception that led to this exception</param>
        public RowExistsException(string Message, Exception InnerException)
            : base(Message, InnerException)
        {
        }

        #endregion

        //==================================================================================
        #region Public Properties


        #endregion

        //==================================================================================
        #region Public Methods


        #endregion

        //==================================================================================
        #region Private/Protected Methods



        #endregion
    }
}
