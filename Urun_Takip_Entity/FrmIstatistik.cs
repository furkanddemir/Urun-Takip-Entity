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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbUrunEntities1 db = new DbUrunEntities1();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            lblMusteriSayisi.Text = db.TBLMUSTERİ.Count().ToString();
            lblKategoriSayisi.Text = db.TBLKATEGORI.Count().ToString();
            lblUrunSayisi.Text = db.TBLURUNLER.Count().ToString();
            lblBeyazEsya.Text = db.TBLURUNLER.Count(x => x.Kategori == 1).ToString();
            lblToplamStok.Text = db.TBLURUNLER.Sum(x => x.Stok).ToString();
            lblBugunkuSatis.Text = db.TBLSATISLAR.Count(x => x.Tarih == bugun).ToString();
            lblToplamKasaTutari.Text = db.TBLSATISLAR.Sum(x => x.Toplam_Tutar).ToString() + " ₺";
            lblBugunkuKasaTutari.Text = db.TBLSATISLAR.Where(x => x.Tarih == bugun).Sum(y => y.Toplam_Tutar).ToString() + " ₺";
            lblEnYuksekFiyatliUrun.Text = (from x in db.TBLURUNLER
                                           orderby x.SatisFiyat descending
                                           select x.UrunAd).FirstOrDefault();
            lblEnDusukFiyatliUrun.Text = (from x in db.TBLURUNLER
                                          orderby x.SatisFiyat ascending
                                          select x.UrunAd).FirstOrDefault();
            lblEnFazlaStokluUrun.Text = (from x in db.TBLURUNLER
                                         orderby x.Stok descending
                                         select x.UrunAd).FirstOrDefault();
            lblEnAzStokluUrun.Text = (from x in db.TBLURUNLER
                                      orderby x.Stok ascending
                                      select x.UrunAd).FirstOrDefault();
        }
    }
}
