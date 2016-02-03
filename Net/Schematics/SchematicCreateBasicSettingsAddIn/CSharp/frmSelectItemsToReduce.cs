﻿// Copyright 2010 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at &lt;your ArcGIS install location&gt;/DeveloperKit10.0/userestrictions.txt.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchematicCreateBasicSettingsAddIn
{
    public partial class frmSelectItemsToReduce : Form
    {
        public event EventHandler cancelFormEvent;
        public string itemList = "";
        public event EventHandler<ReduceEvents> doneFormEvent;

        public frmSelectItemsToReduce()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSelectItemsToReduce_Load);
        }

        void frmSelectItemsToReduce_Load(object sender, EventArgs e)
        {
            string[] myItems;
            char[] splitter = { ';' };

            myItems = itemList.Split(splitter);

            foreach (string s in myItems)
            {
                if (s.Length > 0)
                {
                    this.chkListBox.Items.Add(s);
                }
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            CheckedListBox.CheckedItemCollection selectedItems = this.chkListBox.CheckedItems;
            string[] items = new string[this.chkListBox.CheckedItems.Count];
            if (selectedItems.Count > 0)
            {
                //do something
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    items[i] = selectedItems[i].ToString();
                }
            }

            //raise event back to controller
            ReduceEvents reduce = new ReduceEvents(items);
            this.doneFormEvent(sender,reduce);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.cancelFormEvent(sender, e);
        }
    }
}