using System;
using System.Data;
using System.Windows.Forms;
using VRMS.App_Code.DTO;
using VRMS.App_Code.BLL;
using System.Data.SqlClient;

namespace VRMS
{

    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        DataTable dtUsers;
        DataTable dtPermissions;
        UsersBLL bllUsers;
        UsersDTO dtoUsers;
        PermissionBLL bllPermission;
        SqlDataReader sdrUsers;
        int IdUser;

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            frmAdmin_Clear();
        }
        private void frmAdmin_Clear()
        {
            txtFullname.Text = null;
            txtUsername.Text = null;
            txtPassword.Text = null;
            txtConfirmPassword.Text = null;

            txtUsername.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnExit.Enabled = true;
            
            dgvUsers.Enabled = true;

            dtUsers = new DataTable();
            dtPermissions = new DataTable();
            bllUsers = new UsersBLL();
            bllPermission = new PermissionBLL();

            dtUsers = bllUsers.selectUserDetails();
            dtPermissions = bllPermission.getPermission();
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = dtUsers;

            cboPermission.DataSource = dtPermissions;
            cboPermission.DisplayMember = "Permission";
            cboPermission.ValueMember = "IdPermission";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dtoUsers = new UsersDTO();
            bllUsers = new UsersBLL();

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Hai mật khẩu không giống nhau. Hãy nhập lại");
                return;
            }

            dtoUsers.Fullname = txtFullname.Text;
            dtoUsers.Username = txtUsername.Text;
            dtoUsers.Password = txtPassword.Text;
            dtoUsers.IdPermission = Convert.ToInt32(cboPermission.SelectedValue);
            try
            {
                bllUsers.InsertUser(dtoUsers);
                MessageBox.Show("Đã thêm thành công!","Thông báo");
                frmAdmin_Clear();
            }
            catch (Exception Ex)
            {
                throw;
            }
            
        }
       

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bllUsers = new UsersBLL();

            IdUser = int.Parse(dgvUsers.Rows[e.RowIndex].Cells[0].Value.ToString());
            sdrUsers = bllUsers.selectUserDetailsByID(IdUser);
            if (sdrUsers.Read())
            {
                txtFullname.Text = sdrUsers["Fullname"].ToString();
                txtUsername.Text = sdrUsers["Username"].ToString();
                cboPermission.SelectedValue = sdrUsers["IdPermission"].ToString();
            }

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnExit.Enabled = false;
            txtUsername.Enabled = false;
            dgvUsers.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtoUsers = new UsersDTO();
            bllUsers = new UsersBLL();

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Hai mật khẩu không giống nhau. Hay nhập lại");
                return;
            }
            dtoUsers.Id = IdUser;
            dtoUsers.Fullname = txtFullname.Text;
            dtoUsers.Username = txtUsername.Text;
            dtoUsers.Password = txtPassword.Text;
            dtoUsers.IdPermission = Convert.ToInt32(cboPermission.SelectedValue);
            try
            {
                bllUsers.UpdateUser(dtoUsers);
                MessageBox.Show("Đã sửa thành công!","Thông báo");
                frmAdmin_Clear();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtoUsers = new UsersDTO();
            bllUsers = new UsersBLL();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa không?","Xác nhận",MessageBoxButtons.OKCancel);
            if (dialogResult==DialogResult.OK)
            {
                try
                {
                    bllUsers.DeleteUser(IdUser);
                    MessageBox.Show("Đã xóa thành công!","Thông báo");
                    frmAdmin_Clear();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            frmAdmin_Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if ((txtUsername.Text).Trim()==null)
            {
                btnThem.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
            }
        }
    }
}
