﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    /// <summary>
    /// Thrown when an attempt is made to add a column to the matrix when it already exists inside the matrix
    /// </summary>
    public class ColumnExistsException : ApplicationException
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
        public ColumnExistsException()
            : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The message to describe what has happened</param>
        public ColumnExistsException(string Message)
            : base(Message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Message">The message to describe what has happened</param>
        /// <param name="InnerException">The exception that led to this exception</param>
        public ColumnExistsException(string Message, Exception InnerException)
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
