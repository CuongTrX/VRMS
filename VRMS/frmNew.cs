using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VRMS.App_Code.BLL;
using VRMS.App_Code.DTO;

namespace VRMS
{
    public partial class frmNew : VRMS.Master
    {
        int MaChuPT = -1;
        int MaPT = -1;
        HoSoBLL bllHoSo;
        PhuongTienBLL bllPhuongTien;
        ChuPhuongTienBLL bllChuPT;
        ChuPhuongTienDTO dtoChuPT;
        PhuongTienDTO dtoPhuongTien;
        HoSoDTO dtoHoSo;

        public frmNew()
        {
            InitializeComponent();
        }

        private void frmNew_Load(object sender, EventArgs e)
        {
            frmNew_Clear();
        }
        private void frmNew_Clear()
        {
            ((Control)tpChuPhuongTien).Enabled = true;
            ((Control)tpPhuongTien).Enabled = false;
            ((Control)tpHoSo).Enabled = false;
            btnTiepChuPhuongTien.Enabled = false;
            btnDangKyMoi.Enabled = false;
            tcDangKyMoi.SelectedTab = tpChuPhuongTien;
        }

        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            bllHoSo = new HoSoBLL();
            dtoHoSo = new HoSoDTO();

            dtoHoSo.MaPT = MaPT;
            dtoHoSo.MaChuPT = MaChuPT;
            dtoHoSo.GhiChu = txtGhiChu.Text;

            try
            {
                bllHoSo.insertHoSo(dtoHoSo);
                MessageBox.Show("Đã thêm thành công!","Thông báo");
                frmNew_Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MaPT != -1)
            {
                bllPhuongTien.deletePhuongTien(MaPT);
            }
            if (MaChuPT != -1)
            {
                bllChuPT.deleteChuPhuongTien(MaChuPT);
            }
            frmNew_Clear();
        }

        private void btnLuuChuPhuongTien_Click(object sender, EventArgs e)
        {
            dtoChuPT = new ChuPhuongTienDTO();
            bllChuPT = new ChuPhuongTienBLL();
            

            dtoChuPT.HoDem = txtHoDem.Text;
            dtoChuPT.Ten = txtTen.Text;
            dtoChuPT.NoiThuongTru = txtNoiThuongTru.Text;
            dtoChuPT.DienThoai = txtSoDT.Text;
            dtoChuPT.SoCMND = txtSoCMND.Text;
            dtoChuPT.NgayCap = dtpNgayCap.Value;

            try
            {
                MaChuPT = int.Parse(bllChuPT.insertChuPhuongTien(dtoChuPT).ToString());
                btnLuuChuPhuongTien.Enabled = false;
                btnTiepChuPhuongTien.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnTiepChuPhuongTien_Click(object sender, EventArgs e)
        {
            ((Control)tpPhuongTien).Enabled = true;
            btnTiepPhuongTien.Enabled = false;
            tcDangKyMoi.SelectedTab = tpPhuongTien;
            ((Control)tpChuPhuongTien).Enabled = false;

        }

        private void btnLuuPhuongTien_Click(object sender, EventArgs e)
        {
            dtoPhuongTien = new PhuongTienDTO();
            bllPhuongTien = new PhuongTienBLL();

            dtoPhuongTien.MaChuPT = MaChuPT;
            dtoPhuongTien.BienSo = txtBienSo.Text;
            dtoPhuongTien.NgayDangKyLanDau = dtpNgayDangKyLanDau.Value;
            dtoPhuongTien.NhanHieu = txtNhanHieu.Text;
            dtoPhuongTien.LoaiXe = txtLoaiXe.Text;
            dtoPhuongTien.MauSon = txtMauSon.Text;
            dtoPhuongTien.SoKhung = txtSoKhung.Text;
            dtoPhuongTien.SoMay = txtSoMay.Text;
            dtoPhuongTien.DungTichXiLanh = int.Parse(txtDungTichXiLanh.Text);
            dtoPhuongTien.SoChoNgoi = int.Parse(txtSoChoNgoi.Text);
            try
            {
                MaPT = int.Parse(bllPhuongTien.insertPhuongTien(dtoPhuongTien).ToString());
                btnLuuPhuongTien.Enabled = false;
                btnTiepPhuongTien.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnTiepPhuongTien_Click(object sender, EventArgs e)
        {
            ((Control)tpHoSo).Enabled = true;
            tcDangKyMoi.SelectedTab = tpHoSo;
            ((Control)tpPhuongTien).Enabled = false;
            btnDangKyMoi.Enabled = true;

            txtMaChuPhuongTien.Text = Convert.ToString(MaChuPT);
            txtMaPhuongTien.Text = Convert.ToString(MaPT);
        }
    }
}
