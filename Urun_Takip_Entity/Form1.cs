using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Entity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbUrunEntities1 db = new DbUrunEntities1(); 
        private void btnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TBLMUSTERİ.ToList();
            var degerler = from x in db.TBLMUSTERİ
                           select new
                           {
                               x.MusteriID,
                               x.Ad,
                               x.Soyad,
                               x.Sehir,
                               x.Bakiye
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLMUSTERİ t=new TBLMUSTERİ();
            t.Ad=txtAd.Text;
            t.Bakiye=decimal.Parse(txtBakiye.Text);
            t.Sehir=txtSehir.Text;
            t.Soyad=txtSoyad.Text;
            db.TBLMUSTERİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni müşteri kaydı yapıldı.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);   
            var x = db.TBLMUSTERİ.Find(id);
            db.TBLMUSTERİ.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Müşteri sistemden silindi.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var x = db.TBLMUSTERİ.Find(id);
            x.Ad=txtAd.Text;
            x.Soyad = txtSoyad.Text;
            x.Sehir = txtSehir.Text;
            x.Bakiye=decimal.Parse(txtBakiye.Text) ;
            db.SaveChanges();
            MessageBox.Show("Müşteri bilgisi güncellendi.");
        }
    }
}
