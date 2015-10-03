using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using VRMS.App_Code.BLL;
using VRMS.App_Code;

namespace VRMS
{
    public partial class frmLogin : Form
    {
        int togMove, mpx, mpy;

        UsersBLL bllUsers;
        SqlDataReader sdrUsers;

        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            mpx = e.X;
            mpy = e.Y;
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mpx, MousePosition.Y - mpy);
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int alpha = rand.Next(0, 255);
            int red = rand.Next(0, 255);
            int green = rand.Next(0, 255);
            int blue = rand.Next(0, 255);
            lblError.ForeColor = Color.FromArgb(alpha, red, green, blue);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = false;
            txtUsername.Text = "CuongTrX";
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = null;
            timer1.Enabled = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = null;
            timer1.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bllUsers = new UsersBLL();
            sdrUsers = bllUsers.CheckUser(txtUsername.Text);
            if (sdrUsers.Read())
            {
                if (sdrUsers["Password"].ToString()==func.pHash(txtPassword.Text))
                {
                    if ((int)sdrUsers["IdPermission"]==1)
                    {
                        frmAdmin admin = new frmAdmin();
                        this.Hide();
                        admin.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        SessionManager.IdPermission = (int)sdrUsers["IdPermission"];
                        SessionManager.Fullname = sdrUsers["Fullname"].ToString();
                        Master master = new Master();
                        //Form1 frmForm1 = new Form1();
                        this.Hide();
                        master.ShowDialog();
                        //frmForm1.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    lblError.Text = "Mật khẩu sai! Vui lòng kiểm tra lại...";
                    timer1.Enabled = true;
                }
            }
            else
            {
                lblError.Text = "Tên đăng nhập không đúng! Vui lòng kiểm tra lại...";
                timer1.Enabled = true;
            }
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
