using DoAn_LTWin.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_LTWin
{
    public partial class rptForm : Form
    {
        string maHD;
        public rptForm(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }

        private void rptForm_Load(object sender, EventArgs e)
        {
            using (var context = new TapHoaContextDB())
            {
                var data = (from cthd in context.CHITIETHOADONs
                            join sp in context.SANPHAMs on cthd.MaSP equals sp.MaSP
                            join hd in context.HOADONs on cthd.MaHD equals hd.MaHD
                            join kh in context.KHACHHANGs on hd.MaKH equals kh.MaKH into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            where hd.MaHD == maHD
                            select new HoaDonReportView
                            {
                                MaHD = hd.MaHD,
                                MaKH = kh != null ? kh.MaKH : null,
                                TenKH = kh != null ? kh.TenKH : null,
                                SDT = kh != null ? kh.SDT : null,
                                MaNV = hd.MaNV,
                                NgayLap = hd.NgayLap,
                                MaSP = sp.MaSP,
                                TenSP = sp.TenSP,
                                SoLuong = cthd.SoLuong,
                                DonGia = cthd.DonGia,
                                TongHang = cthd.SoLuong * cthd.DonGia
                            }).ToList();

                decimal? tong = data.Sum(x => x.TongHang);
                decimal? giam = data.FirstOrDefault()?.MaKH != null ? tong * 0.03m : 0;
                decimal? thanhToan = tong - giam;
                data.ForEach(x => { x.GiamGia = (giam ?? 0); x.ThanhToan = (thanhToan??0); });

                ReportDataSource rds = new ReportDataSource("HoaDonDataSet", data);
                reportViewer1.LocalReport.ReportPath = @"C:\DanhNguyeen\windows\source\repos\DoAn_LTWin\DoAn_LTWin\rptHoaDon.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }
            

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
