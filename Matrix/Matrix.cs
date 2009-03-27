using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    /// <summary>
    /// A Class representing a Matrix.
    /// </summary>
    /// <typeparam name="TRow">The type that represents any single row in the matrix</typeparam>
    /// <typeparam name="TCol">The data type that represents any single column in the matrix</typeparam>
    /// <typeparam name="TCell">The data type of the data in a cell</typeparam>
    [Serializable]
    public class Matrix<TRow, TCol, TCell>
        where TCell : IComparable<TCell>
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

        /// <summary>
        /// The matrix
        /// </summary>
        protected Dictionary<TRow, Dictionary<TCol, TCell>> matrix;

        /// <summary>
        /// Maintains a list of all the row headings in this matrix
        /// </summary>
        protected List<TRow> rowHeadings;

        /// <summary>
        /// Maintains a list of all the column headings in this matrix
        /// </summary>
        protected List<TCol> colHeadings;

        /// <summary>
        /// Holds the default cell value for cells in the matrix
        /// </summary>
        protected TCell defaultCellValue;

        #endregion

        //==================================================================================
        #region Constructors/Destructors

        public Matrix()
        {
            //Initialize the row and column headings
            rowHeadings = new List<TRow>();
            colHeadings = new List<TCol>();

            matrix = new Dictionary<TRow, Dictionary<TCol, TCell>>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="RowValues">The labels for the rows</param>
        /// <param name="ColumnHeadings">The labels for the columns</param>
        /// <param name="DefaultValue">The default values for the cells</param>
        public Matrix(TRow[] RowValues, TCol[] ColumnHeadings, TCell DefaultValue)
        {
            //Initialize the row and column headings
            rowHeadings = new List<TRow>();
            colHeadings = new List<TCol>();

            //Generate the matrix
            GenerateMatrix(RowValues, ColumnHeadings, DefaultValue);
        }

        #endregion

        //==================================================================================
        #region Public Properties

        /// <summary>
        /// Gets or Sets the specified cell
        /// </summary>
        /// <param name="Row">The row in which the cell exists</param>
        /// <param name="Column">The column in which the cell exists</param>
        /// <returns>The value inside the cell</returns>
        public TCell this[TRow Row, TCol Column]
        {
            get { return matrix[Row][Column]; }
            set { matrix[Row][Column] = value; }
        }

        /// <summary>
        /// Gets the number of rows in this matrix
        /// </summary>
        public int RowCount
        {
            get { return rowHeadings.Count; }
        }

        /// <summary>
        /// Gets the number of columns in the matrix
        /// </summary>
        public int ColumnCount
        {
            get { return colHeadings.Count; }
        }

        #endregion

        //==================================================================================
        #region Public Methods

        #region Row/Column adding/removing

        /// <summary>
        /// Adds Rows to the matrix
        /// </summary>
        /// <param name="RowLabels">The row labels to add</param>
        /// <param name="CellValue">The value to place in each cell of the new row</param>
        public void AddRows(IEnumerable<TRow> RowLabels, TCell CellValue)
        {
            //Validate the array that we are adding
            foreach (TRow curRow in RowLabels)
            {
                if (rowHeadings.Contains(curRow))
                {
                    throw new RowExistsException("The row \"" + curRow.ToString() + "\" already exists in this matrix");
                }
            }

            //Add the headings to the list of headings
            rowHeadings.AddRange(RowLabels);

            //Add the rows to the matrix
            foreach (TRow curRow in RowLabels)
            {
                matrix.Add(curRow, new Dictionary<TCol,TCell>());

                //Add the cells
                foreach (TCol curCol in colHeadings)
                {
                    matrix[curRow].Add(curCol, CellValue);
                }
            }
        }

        /// <summary>
        /// Adds columns to the matrix
        /// </summary>
        /// <param name="ColumnHeadings">The column labels to add</param>
        /// <param name="DefaultCellValue">The value to place into each created cell</param>
        /// <exception cref="NoRowsException">Thrown when no rows exist in the matrix. The
        /// matrix needs rows before it can have columns because of the way it is designed</exception>
        public void AddColumns(IEnumerable<TCol> ColumnHeadings, TCell DefaultCellValue)
        {
            //Validate the array that we are adding
            foreach (TCol curCol in ColumnHeadings)
            {
                if (colHeadings.Contains(curCol))
                {
                    throw new ColumnExistsException("The column \"" + curCol.ToString() + "\" already exists in this matrix");
                }
            }

            colHeadings.AddRange(ColumnHeadings);

            //Loop through each row, adding the cells
            foreach (TRow curRow in matrix.Keys)
            {
                foreach (TCol curCol in ColumnHeadings)
                {
                    matrix[curRow].Add(curCol, DefaultCellValue);
                }
            }
        }

        /// <summary>
        /// Adds Rows to the matrix
        /// </summary>
        /// <param name="RowLabels">The row labels to add</param>
        /// <param name="CellValue">The value to place in each cell of the new row</param>
        public void AddRows(IEnumerable<TRow> RowLabels)
        {
            AddRows(RowLabels, defaultCellValue);
        }

        /// <summary>
        /// Adds columns to the matrix
        /// </summary>
        /// <param name="ColumnHeadings">The column labels to add</param>
        /// <param name="DefaultCellValue">The value to place into each created cell</param>
        /// <exception cref="NoRowsException">Thrown when no rows exist in the matrix. The
        /// matrix needs rows before it can have columns because of the way it is designed</exception>
        public void AddColumns(IEnumerable<TCol> ColumnHeadings)
        {
            AddColumns(ColumnHeadings, defaultCellValue);
        }

        /// <summary>
        /// Adds a single row to the matrix
        /// </summary>
        /// <param name="RowLabel">The row to add</param>
        /// <param name="DefaultCellValue">The value to set the cells in the new row to</param>
        public void AddRow(TRow RowLabel, TCell DefaultCellValue)
        {
            this.AddRows(new TRow[] { RowLabel }, DefaultCellValue);
        }

        /// <summary>
        /// Adds a single row to the matrix
        /// </summary>
        /// <param name="RowLabel">The row heading to add</param>
        public void AddRow(TRow RowLabel)
        {
            this.AddRow(RowLabel, defaultCellValue);
        }

        /// <summary>
        /// Adds a single column to the matrix
        /// </summary>
        /// <param name="ColumnLabel">The column to add</param>
        /// <param name="DefaultCellValue">The value to set the cells in the new column to</param>
        public void AddColumn(TCol ColumnLabel, TCell DefaultCellValue)
        {
            this.AddColumns(new TCol[] { ColumnLabel }, DefaultCellValue);
        }

        /// <summary>
        /// Adds a single column to the matrix
        /// </summary>
        /// <param name="ColumnLabel">The column heading to add</param>
        public void AddColumn(TCol ColumnLabel)
        {
            this.AddColumn(ColumnLabel, defaultCellValue);
        }

        #endregion

        #region Row/Column Fetching

        /// <summary>
        /// Gets the column labels in this matrix
        /// </summary>
        /// <returns>An Array containing the column labels</returns>
        public TCol[] GetColumnLabels()
        {
            return colHeadings.ToArray();
        }

        /// <summary>
        /// Fetches the row labels for this matrix
        /// </summary>
        /// <returns>An array of row labels, or NULL if no rows are present in the matrix</returns>
        public TRow[] GetRowLabels()
        {
            return rowHeadings.ToArray();
        }

        #endregion

        #region Matrix Initialization

        /// <summary>
        /// Generates the matrix with default cell values.
        /// </summary>
        /// <param name="RowLabels">The labels to refer to the rows</param>
        /// <param name="ColumnLabels">The labels to refer to the columns</param>
        /// <param name="DefaultCellValue">The default value for the cells</param>
        public void GenerateMatrix(TRow[] RowLabels, TCol[] ColumnLabels, TCell DefaultCellValue)
        {
            //Initialize the matrix
            matrix = new Dictionary<TRow, Dictionary<TCol, TCell>>();

            //Reset the row and column headings
            rowHeadings.Clear();
            rowHeadings.Capacity = RowLabels.Length;

            colHeadings.Clear();
            colHeadings.Capacity = ColumnLabels.Length;

            //Store the default cell value
            defaultCellValue = DefaultCellValue;

            //Add the new rows and columns
            this.AddRows(RowLabels, DefaultCellValue);
            this.AddColumns(ColumnLabels, DefaultCellValue);




        }

        #endregion

        #region Matrix Validation

        /// <summary>
        /// Searches through the matrix to find a specified value
        /// </summary>
        /// <param name="Value">The value to search for</param>
        /// <returns>TRUE if the value was found, FALSE otherwise</returns>
        public bool ContainsValue(TCell Value)
        {
            bool retVal = false;

            //Loop through the rows searching for the value
            int i = 0;
            while (i < rowHeadings.Count && !retVal)
            {
                if (matrix[rowHeadings[i]].ContainsValue(Value))
                {
                    retVal = true;
                }
                else
                {
                    i++;
                }
            }

            return retVal;
        }

        #endregion

        #endregion

        //==================================================================================
        #region Private/Protected Methods


        #endregion
    }
}
