using System.Windows.Forms;
using VRMS.App_Code;

namespace VRMS
{
    public partial class Master : Form
    {

        public Master()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            checkPermission();
            lblStatus.Text = SessionManager.Fullname;
        }
        private void checkPermission()
        {
            switch (SessionManager.IdPermission)
            {
                case 2:
                    rtNghiepVu.Visible = true;
                    rtCapNhat.Visible = true;
                    rtTimKiem.Visible = true;
                    rtThongKe.Visible = true;
                    break;
                case 3:
                    rtNghiepVu.Visible = false;
                    rtCapNhat.Visible = false;
                    rtTimKiem.Visible = true;
                    rtThongKe.Visible = true;
                    break;
                case 4:
                    rtNghiepVu.Visible = false;
                    rtCapNhat.Visible = false;
                    rtTimKiem.Visible = false;
                    rtThongKe.Visible = true;
                    break;
                default:
                    break;
            }
        }
        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, System.EventArgs e)
        {
            frmNew frmNew = new frmNew();
            this.Hide();
            frmNew.ShowDialog();
            this.Show();
        }
    }
}
