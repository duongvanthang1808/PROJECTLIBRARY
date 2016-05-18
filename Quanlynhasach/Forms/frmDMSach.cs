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
    public partial class frmDMSach : Form
    {
        public frmDMSach()
        {
            InitializeComponent();
        }
        DataTable tblSach;
        private void frmDMSach_Load(object sender, EventArgs e)
        {
            txtMaS.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Functions.FillCombo("SELECT Matg, TenTg FROM tblTacgia",
cboMatg, "Matg", "TenTg");
            Functions.FillCombo("SELECT MaNXB, TenNXB FROM tblNhacungcap",
cboManxb, "MaNXB", "TenNXB");


        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblSach";
            tblSach = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblSach;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Mã nhà xuất bản";
            DataGridView.Columns[3].HeaderText = "Mã Tác giả";
            DataGridView.Columns[4].HeaderText = "Số lượng";
            DataGridView.Columns[5].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[6].HeaderText = "Đơn giá bán";
            DataGridView.Columns[7].HeaderText = "Anh";
            DataGridView.Columns[8].HeaderText = "Ghi chú";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 150;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 150;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaS.Text = "";
            txtTenS.Text = "";
            txtSoluong.Text = "0";
            txtDongiaban.Text = "0";
            txtDongianhap.Text = "0";
            msGhiChu.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaS.Enabled = true;
            txtMaS.Focus();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaS.Focus();
                return;
            }
            if (txtTenS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenS.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtDongiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
                return;
            }

            sql = "SELECT Mahang FROM tblSach WHERE Mahang=N'" + txtMaS.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nkhách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaS.Focus();
                txtMaS.Text = "";
                return;
            }
            sql = "INSERT INTO tblSach(Mahang,Tenhang,MaNXB,Matg,Dongianhap,Dongiaban,Ghichu,Anh,Soluong) VALUES (N'" + txtMaS.Text.Trim() + "',N'" + txtTenS.Text.Trim() +
                "',N'" + cboManxb.SelectedValue.ToString() + "','" +
                cboMatg.SelectedValue.ToString() + "','" + float.Parse(txtDongianhap.Text) + "','" +
                float.Parse(txtDongiaban.Text) + "','" + msGhiChu.Text + "','" + txtanh.Text + "','" + float.Parse(txtSoluong.Text) + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaS.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMaS.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenS.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (msGhiChu.Text == "")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msGhiChu.Focus();
                return;
            }

            sql = "UPDATE tblSach SET  Tenhang=N'" + txtTenS.Text.Trim().ToString() +
                    "',MaNXB=N'" + cboManxb.SelectedValue.ToString() +
                    "',Matg='" + cboMatg.SelectedValue.ToString() +
                    "',Soluong='" + float.Parse(txtSoluong.Text) + "',Dongianhap='" + float.Parse(txtDongianhap.Text) +
                    "',Dongiaban = '" + float.Parse(txtDongiaban.Text) + "',Ghichu = '" + msGhiChu.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMaS.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSach WHERE Mahang=N'" + txtMaS.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaS.Enabled = false;

        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaS.Focus();
                return;
            }
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
    MessageBoxIcon.Information);
                return;
            }
            txtMaS.Text = DataGridView.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenS.Text = DataGridView.CurrentRow.Cells["Tenhang"].Value.ToString();

            ma = DataGridView.CurrentRow.Cells["MaNXB"].Value.ToString();
            cboManxb.Text = Functions.GetFieldValues("SELECT MaNXB FROM tblNhacungcap WHERE MaNXB = N'" + ma + "'");

            ma = DataGridView.CurrentRow.Cells["Matg"].Value.ToString();
            cboMatg.Text = Functions.GetFieldValues("SELECT Matg FROM tblTacgia WHERE Matg = N'" + ma + "'");

            txtSoluong.Text = DataGridView.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDongiaban.Text = DataGridView.CurrentRow.Cells["Dongiaban"].Value.ToString();
            txtDongianhap.Text = DataGridView.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtanh.Text = DataGridView.CurrentRow.Cells["Anh"].Value.ToString();
            msGhiChu.Text = DataGridView.CurrentRow.Cells["Ghichu"].Value.ToString();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;

        }

    }
}
