﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Web;

namespace Utils
{
    /// <summary>
    /// BulkEditGridView allows users to edit multiple rows of a gridview at once, and have them
    /// all saved.
    /// </summary>
    [
    DefaultEvent("SelectedIndexChanged"),
    Designer("System.Web.UI.Design.WebControls.GridViewDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
    ControlValueProperty("SelectedValue"),
    ]
    public class BulkEditGridView : System.Web.UI.WebControls.GridView
    {
        //key for the RowInserting event handler list
        public static readonly object RowInsertingEvent = new object();

        private List<int> dirtyRows = new List<int>();
        private List<int> newRows = new List<int>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BulkEditGridView()
        {
        }

        /// <summary>
        /// Modifies the creation of the row to set all rows as editable.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="dataSourceIndex"></param>
        /// <param name="rowType"></param>
        /// <param name="rowState"></param>
        /// <returns></returns>
        protected override GridViewRow CreateRow(int rowIndex, int dataSourceIndex, DataControlRowType rowType, DataControlRowState rowState)
        {
            return base.CreateRow(rowIndex, dataSourceIndex, rowType, rowState | DataControlRowState.Edit);
        }

        public List<GridViewRow> DirtyRows
        {
            get
            {
                List<GridViewRow> drs = new List<GridViewRow>();
                foreach (int rowIndex in dirtyRows)
                {
                    drs.Add(this.Rows[rowIndex]);
                }

                return drs;
            }
        }

        /// <summary>
        /// Adds event handlers to controls in all the editable cells.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="fields"></param>
        protected override void InitializeRow(GridViewRow row, DataControlField[] fields)
        {
            base.InitializeRow(row, fields);
            foreach (TableCell cell in row.Cells)
            {
                if (cell.Controls.Count > 0)
                {
                    AddChangedHandlers(cell.Controls);
                }
            }
        }

        /// <summary>
        /// Adds an event handler to editable controls.
        /// </summary>
        /// <param name="controls"></param>
        private void AddChangedHandlers(ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).TextChanged += new EventHandler(this.HandleRowChanged);
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).CheckedChanged += new EventHandler(this.HandleRowChanged);
                }
                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).SelectedIndexChanged += new EventHandler(this.HandleRowChanged);
                }
                ////could add recursion if we are missing some controls.
                //else if (ctrl.Controls.Count > 0 && !(ctrl is INamingContainer) )
                //{
                //    AddChangedHandlers(ctrl.Controls);
                //}
            }
        }


        /// <summary>
        /// This gets called when a row is changed.  Store the id of the row and wait to update
        /// until save is called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void HandleRowChanged(object sender, EventArgs args)
        {
            GridViewRow row = ((Control)sender).NamingContainer as GridViewRow;
            if (null != row)
            {
                if (0 != (row.RowState & DataControlRowState.Insert))
                {
                    int altRowIndex = this.InnerTable.Rows.GetRowIndex(row);
                    if (false == newRows.Contains(altRowIndex))
                        newRows.Add(altRowIndex);
                }
                else
                {
                    if (false == dirtyRows.Contains(row.RowIndex))
                        dirtyRows.Add(row.RowIndex);
                }
            }

        }

        /// <summary>
        /// Setting this property will cause the grid to update all modified records when 
        /// this button is clicked.  It currently supports Button, ImageButton, and LinkButton.
        /// If you set this property, you do not need to call save programatically.
        /// </summary>
        [IDReferenceProperty(typeof(Control))]
        public string SaveButtonID
        {
            get
            {
                return (string)(this.ViewState["SaveButtonID"] ?? String.Empty);
            }
            set
            {
                this.ViewState["SaveButtonID"] = value;
            }
        }

        /// <summary>
        /// Attaches an eventhandler to the onclick method of the save button.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Attach an event handler to the save button.
            if (false == string.IsNullOrEmpty(this.SaveButtonID))
            {
                Control btn = RecursiveFindControl(this.NamingContainer, this.SaveButtonID);
                if (null != btn)
                {
                    if (btn is Button)
                    {
                        ((Button)btn).Click += new EventHandler(SaveClicked);
                    }
                    else if (btn is LinkButton)
                    {
                        ((LinkButton)btn).Click += new EventHandler(SaveClicked);
                    }
                    else if (btn is ImageButton)
                    {
                        ((ImageButton)btn).Click += new ImageClickEventHandler(SaveClicked);
                    }
                }
            }
        }

        /// <summary>
        /// Looks for a control recursively up the control tree.  We need this because Page.FindControl
        /// does not find the control if we are inside a masterpage content section.
        /// </summary>
        /// <param name="namingcontainer"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        private Control RecursiveFindControl(Control namingcontainer, string controlName)
        {
            Control c = namingcontainer.FindControl(controlName);

            if (c != null)
                return c;

            if (namingcontainer.NamingContainer != null)
                return RecursiveFindControl(namingcontainer.NamingContainer, controlName);

            return null;
        }

        /// <summary>
        /// Handles the save event, and calls the save method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveClicked(object sender, EventArgs e)
        {
            this.Save();
            this.DataBind();
        }

        /// <summary>
        /// Saves any modified rows.  This is called automatically if the SaveButtonId is set.
        /// </summary>
        public void Save()
        {
            try
            {
                foreach (int row in dirtyRows)
                {
                    //TODO: need to check if we really want false here.  Probably want to pull this
                    //fron the save button.
                    this.UpdateRow(row, false);
                }

                foreach (int row in newRows)
                {
                    //Make the datasource save a new row.
                    this.InsertRow(row, false);
                }
            }
            finally
            {
                dirtyRows.Clear();
                newRows.Clear();
            }
        }

        /// <summary>
        /// Prepares the <see cref="RowInserting"/> event and calls insert on the DataSource.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="causesValidation"></param>
        private void InsertRow(int rowIndex, bool causesValidation)
        {
            GridViewRow row = null;

            if ((!causesValidation || (this.Page == null)) || this.Page.IsValid)
            {
                DataSourceView dsv = null;
                bool useDataSource = base.IsBoundUsingDataSourceID;
                if (useDataSource)
                {
                    dsv = this.GetData();
                    if (dsv == null)
                    {
                        throw new HttpException("DataSource Returned Null View");
                    }
                }
                GridViewInsertEventArgs args = new GridViewInsertEventArgs(rowIndex);
                if (useDataSource)
                {
                    if ((row == null) && (this.InnerTable.Rows.Count > rowIndex))
                    {
                        row = this.InnerTable.Rows[rowIndex] as GridViewRow;
                    }
                    if (row != null)
                    {
                        this.ExtractRowValues(args.NewValues, row, true, false);
                    }
                }

                this.OnRowInserting(args);

                if (!args.Cancel && useDataSource)
                {
                    dsv.Insert(args.NewValues, new DataSourceViewOperationCallback(DataSourceViewInsertCallback));
                }
            }
        }

        /// <summary>
        /// Callback for the datasource's insert command.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private bool DataSourceViewInsertCallback(int i, Exception ex)
        {
            if (null != ex)
            {
                throw ex;
            }

            return true;
        }


        /// <summary>
        /// Fires the <see cref="RowInserting"/> event.
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnRowInserting(GridViewInsertEventArgs args)
        {
            Delegate handler = this.Events[RowInsertingEvent];
            if (null != handler)
                handler.DynamicInvoke(this, args);
        }

        /// <summary>
        /// Event fires when new row has been edited, and save is clicked.
        /// </summary>
        public event GridViewInsertEventHandler RowInserting
        {
            add
            {
                this.Events.AddHandler(RowInsertingEvent, value);
            }
            remove
            {
                this.Events.RemoveHandler(RowInsertingEvent, value);
            }
        }

        /// <summary>
        /// Access to the GridView's inner table.
        /// </summary>
        protected Table InnerTable
        {
            get
            {
                if (false == this.HasControls())
                    return null;

                return (Table)this.Controls[0];
            }
        }

        /// <summary>
        /// Enables inline inserting.  Off by default.
        /// </summary>
        public bool EnableInsert
        {
            get
            {
                return (bool)(this.ViewState["EnableInsert"] ?? false);
            }
            set
            {
                this.ViewState["EnableInsert"] = value;
            }
        }

        /// <summary>
        /// We have to recreate our insert row so we can load the postback info from it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnPagePreLoad(object sender, EventArgs e)
        {
            base.OnPagePreLoad(sender, e);

            if (this.EnableInsert && this.Page.IsPostBack)
            {
                this.CreateInsertRow();
            }
        }

        /// <summary>
        /// After the controls are databound, add a row to the end.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDataBound(EventArgs e)
        {
            if (this.EnableInsert)
            {
                this.CreateInsertRow();
            }

            base.OnDataBound(e);
        }

        /// <summary>
        /// Creates the insert row and adds it to the inner table.
        /// </summary>
        protected virtual void CreateInsertRow()
        {
            GridViewRow row = this.CreateRow(this.Rows.Count, -1, DataControlRowType.DataRow, DataControlRowState.Insert);

            DataControlField[] fields = new DataControlField[this.Columns.Count];
            this.Columns.CopyTo(fields, 0);

            this.InitializeRow(row, fields);

            int index = this.InnerTable.Rows.Count - (this.ShowFooter ? 1 : 0);
            this.InnerTable.Rows.AddAt(index, row);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void GridViewInsertEventHandler(object sender, GridViewInsertEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    public class GridViewInsertEventArgs : CancelEventArgs
    {
        private int _rowIndex;
        private IOrderedDictionary _values;

        public GridViewInsertEventArgs(int rowIndex)
            : base(false)
        {
            this._rowIndex = rowIndex;
        }

        /// <summary>
        /// Gets a dictionary containing the revised values of the non-key field name/value
        /// pairs in the row to update.
        /// </summary>
        public IOrderedDictionary NewValues
        {
            get
            {
                if (this._values == null)
                {
                    this._values = new OrderedDictionary();
                }
                return this._values;
            }
        }

        /// <summary>
        /// Gets the index of the row being updated.
        /// </summary>
        public int RowIndex { get { return this._rowIndex; } }
    }
}
