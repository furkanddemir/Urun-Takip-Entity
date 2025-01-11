using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Entity
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        DbUrunEntities1 db = new DbUrunEntities1();

        void urunListesi()
        {
            var urunler = from x in db.TBLURUNLER
                          select new
                          {
                              x.UrunId,
                              x.UrunAd,
                              x.Stok,
                              x.AlisFiyat,
                              x.SatisFiyat,
                              x.TBLKATEGORI.Ad
                          };
            dataGridView1.DataSource = urunler.ToList();
        }
        void temizle()
        {
            txtAlisFiyat.Text = "";
            txtId.Text = "";
            txtUrunAd.Text = "";
            txtSatisFiyat.Text = "";
            txtStok.Text = "";
        }
        private void btnListele_Click(object sender, EventArgs e)
        {

            // dataGridView1.DataSource = db.TBLURUNLER.ToList();

           urunListesi();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            urunListesi();
            comboBox1.DataSource = db.TBLKATEGORI.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Ad";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNLER t = new TBLURUNLER();
            t.UrunAd = txtUrunAd.Text;
            t.Stok = short.Parse(txtStok.Text);
            t.AlisFiyat = decimal.Parse(txtAlisFiyat.Text);
            t.SatisFiyat = decimal.Parse(txtSatisFiyat.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.TBLURUNLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün başarılı bir şekilde sisteme kaydedildi.");
            urunListesi();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
           // comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = int.Parse(txtId.Text);
                var x = db.TBLURUNLER.Find(id);
                db.TBLURUNLER.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Ürün başarılı bir şekilde sistemden silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Lütfen verileri listeledikten sonra bir satıra tıklayıp silmek istediğiniz kaydı seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            urunListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var x = db.TBLURUNLER.Find(id);
            x.UrunAd = txtUrunAd.Text;
            x.Stok = short.Parse(txtStok.Text);
            x.AlisFiyat = decimal.Parse(txtAlisFiyat.Text);
            x.SatisFiyat = decimal.Parse(txtSatisFiyat.Text);
            x.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün başarılı bir şekilde güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunListesi();
        }
        
    }
}
