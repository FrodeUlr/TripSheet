﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TripSheet_SQLite
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private string uid;
        public Edit(string UID)
        {
            InitializeComponent();
            uid = UID;
            LoadData(UID);
        }

        private void LoadData(string uID)
        {
            HelperLib.Model.TripSheetDetail test = Startup.sqlSlave.tripSheetModel.TripSheetDetail.First(a => a.Id == uID);
            txtName.Text = test.Name;
            txtDetails.Text = test.Details;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "")
            {
                Startup.sqlSlave.tripSheetModel.TripSheetDetail.First(a => a.Id == uid).Name = txtName.Text;
                Startup.sqlSlave.tripSheetModel.TripSheetDetail.First(a => a.Id == uid).Details = txtDetails.Text;
                Startup.sqlSlave.tripSheetModel.SaveChanges();
            }
            Close();
        }
    }
}
