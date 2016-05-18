using Quanlynhasach.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quanlynhasach.Forms
{
    public partial class frmHangTon : Form
    {
        public frmHangTon()
        {
            InitializeComponent();
        }

        private void frmHangTon_Load(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT Mahang, Tenhang FROM tblSach", cboTenSach, "Mahang", "Tenhang");
        }

        private void cboTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = Functions.GetFieldValues("select Soluong from tblSach where Mahang = '" + cboTenSach.SelectedValue.ToString() + "'");
        }
    }
}
