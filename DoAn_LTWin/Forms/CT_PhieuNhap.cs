using DoAn_LTWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWin.Forms
{
    public partial class CT_PhieuNhap : Form
    {
        private mainMenu menu;
        private string maPhieuNhap;
        public CT_PhieuNhap(mainMenu main,string MaPhieuNhap)
        {
            InitializeComponent();
            this.menu = main;
            TapHoaContextDB context = new TapHoaContextDB();
            List<CHITIETPHIEUNHAP> listCTPN = context.CHITIETPHIEUNHAPs.ToList();
            maPhieuNhap = MaPhieuNhap;
            txtMaPN.Text = maPhieuNhap;
            BindGrid(listCTPN);
            tongTien();
        }

        private void BindGrid(List<CHITIETPHIEUNHAP> listCTPN)
        {
            dgvHangNhap.Rows.Clear();
            foreach (var item in listCTPN)
            {
                if(item.MaPN != maPhieuNhap)
                {
                    continue;
                }
                int index = dgvHangNhap.Rows.Add();
                dgvHangNhap.Rows[index].Cells[0].Value = item.MaPN;
                dgvHangNhap.Rows[index].Cells[1].Value = item.MaCTPN;
                dgvHangNhap.Rows[index].Cells[2].Value = item.MaSP;
                dgvHangNhap.Rows[index].Cells[3].Value = item.SoLuong;
                dgvHangNhap.Rows[index].Cells[4].Value = item.DonGiaNhap;
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            menu.openChildForm1(new Forms.NhapSanPham(menu), sender);
        }

        private void CT_PhieuNhap_Load(object sender, EventArgs e)
        {
            txtMaPN.Text = maPhieuNhap;
        }

        private void dgvHangNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHangNhap.CurrentRow != null && dgvHangNhap.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvHangNhap.CurrentRow;
                txtMaCTNhap.Text = Convert.ToString(row.Cells[1].Value);
                txtMaSP.Text = Convert.ToString(row.Cells[2].Value);
                txtSoluong.Text = Convert.ToString(row.Cells[3].Value);
                if (row.Cells[4].Value != null)
                {
                    decimal donGia = Convert.ToDecimal(row.Cells[4].Value);
                    txtDonGiaNhap.Text = donGia.ToString("N0");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtMaCTNhap.Text == "" || txtMaSP.Text == "" || txtSoluong.Text == "" || txtDonGiaNhap.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return;
            }
            int rowCheck = dgvHangNhap.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvHangNhap.Rows[i].Cells[0].Value.ToString() == txtMaSP.Text)
                {
                    MessageBox.Show("Mã chi tiết phiếu đã tồn tại. Vui lòng sử dụng mã khác.");
                    return;
                }
            }
            TapHoaContextDB context = new TapHoaContextDB();
            SANPHAM sp = context.SANPHAMs.SingleOrDefault(s => s.MaSP == txtMaSP.Text);
            CHITIETPHIEUNHAP newCTPN = new CHITIETPHIEUNHAP
            {
                MaCTPN = txtMaCTNhap.Text,
                MaPN = txtMaPN.Text,
                MaSP = txtMaSP.Text,
                SoLuong = int.Parse(txtSoluong.Text),
                DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text)
            };
            sp.SoLuongTon += newCTPN.SoLuong ?? 0;
            context.CHITIETPHIEUNHAPs.Add(newCTPN);
            context.SaveChanges();
            BindGrid(context.CHITIETPHIEUNHAPs.ToList());
            tongTien();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TapHoaContextDB context = new TapHoaContextDB();
            List<CHITIETPHIEUNHAP> listCTPN = context.CHITIETPHIEUNHAPs.ToList();
            int rowCheck = dgvHangNhap.RowCount;
            for (int i = 0; i < rowCheck - 1; i++)
            {
                if (dgvHangNhap.Rows[i].Cells[0].Value.ToString() == txtMaPN.Text)
                {
                    var pnToUpdate = context.CHITIETPHIEUNHAPs.SingleOrDefault(pn => pn.MaCTPN == txtMaCTNhap.Text);
                    var spToUpdate = context.SANPHAMs.SingleOrDefault(sp => sp.MaSP == txtMaSP.Text);
                    if (pnToUpdate != null)
                    {
                        pnToUpdate.MaSP = txtMaSP.Text;
                        spToUpdate.SoLuongTon -= pnToUpdate.SoLuong ?? 0;
                        pnToUpdate.SoLuong = int.Parse(txtSoluong.Text);
                        spToUpdate.SoLuongTon += pnToUpdate.SoLuong ?? 0;
                        pnToUpdate.DonGiaNhap = decimal.Parse(txtDonGiaNhap.Text);
                        context.SaveChanges();
                        BindGrid(listCTPN);
                        MessageBox.Show("Cập nhật phiếu nhập thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu cần cập nhật.");
                    }
                }
            }
            tongTien();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaCTNhap.Text))
            {
                MessageBox.Show("Vui lòng chọn phiếu cần xóa");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa phiếu nhập {txtMaPN.Text}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (TapHoaContextDB context = new TapHoaContextDB())
                    {
                        var pnToDelete = context.CHITIETPHIEUNHAPs
                            .SingleOrDefault(pn => pn.MaCTPN == txtMaCTNhap.Text);
                        var sptoDelete = context.SANPHAMs
                            .SingleOrDefault(sp => sp.MaSP == txtMaSP.Text);
                        if (pnToDelete != null)
                        {
                            context.CHITIETPHIEUNHAPs.Remove(pnToDelete);
                            sptoDelete.SoLuongTon -= pnToDelete.SoLuong;
                            context.SaveChanges();
                            BindGrid(context.CHITIETPHIEUNHAPs.ToList());
                            txtMaCTNhap.Clear();
                            txtMaSP.Clear();
                            txtSoluong.Clear();
                            txtDonGiaNhap.Clear();

                            MessageBox.Show("Xóa thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm cần xóa.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
                tongTien();
            }
        }
        private void tongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvHangNhap.Rows)
            {
                if (row.Cells[4].Value != null && row.Cells[3].Value != null)
                {
                    decimal donGia = Convert.ToDecimal(row.Cells[4].Value);
                    int soLuong = Convert.ToInt32(row.Cells[3].Value);
                    tongTien += donGia * soLuong;
                }
            }
            using (TapHoaContextDB context = new TapHoaContextDB())
            {
                var phieuNhap = context.PHIEUNHAPs.FirstOrDefault(p => p.MaPN == maPhieuNhap);
                if (phieuNhap != null)
                {
                    phieuNhap.TongTien = tongTien;
                    context.SaveChanges();
                }
            }
            txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";

        }
    }
}
