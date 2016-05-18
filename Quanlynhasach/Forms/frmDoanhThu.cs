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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            txtSoluongban.ReadOnly = true;
            txtdongianhap.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtDoanhthu.ReadOnly = true;
            txtLoinhuan.ReadOnly = true;

            Functions.FillCombo("select Mahang, Tenhang from tblSach", cboMasach, "Mahang", "Tenhang");
           
        }

        private void cboMasach_TextChanged(object sender, EventArgs e)
        {
            double soluong, dongianhap, dongiaban, doanhthu, loinhuan;

           

            txtSoluongban.Text = Functions.GetFieldValues("select sum(Soluong) from tblCHitietHDBan where Mahang = '" +
                cboMasach.SelectedValue + "'");
            txtdongianhap.Text = Functions.GetFieldValues("select Dongianhap from tblSach where Mahang = '" +
                cboMasach.SelectedValue + "'");
            txtDongiaban.Text = Functions.GetFieldValues("select Dongiaban from tblSach where Mahang = '" +
                cboMasach.SelectedValue + "'");
               

            if (txtSoluongban.Text == "")
            {
                soluong = 0;
            }
            else soluong = Convert.ToDouble(txtSoluongban.Text);
            if (txtdongianhap.Text == "")
            {
                dongianhap = 0;
            }
            else dongianhap = Convert.ToDouble(txtdongianhap.Text);
            if (txtDongiaban.Text == "")
            {
                dongiaban = 0;
            }
            else dongiaban = Convert.ToDouble(txtDongiaban.Text);

            doanhthu = soluong * dongiaban;
            loinhuan = doanhthu - soluong * dongianhap;

            txtDoanhthu.Text = doanhthu.ToString();
            txtLoinhuan.Text = loinhuan.ToString();

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string sql,maHDBan;
            double soluong, dongianhap, dongiaban, doanhthu, loinhuan;

            if (txtThang.Text == "" && txtNam.Text == "")
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...",
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT sum(Tongtien) FROM tblHDBan WHERE 1=1";

            if (txtThang.Text != "")
                sql = sql + " AND MONTH(Ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(Ngayban) =" + txtNam.Text;

            txtDoanhThuthang.Text = Functions.GetFieldValues(sql);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
