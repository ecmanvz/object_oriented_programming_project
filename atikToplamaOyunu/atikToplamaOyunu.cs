using atikToplamaOyunu.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atikToplamaOyunu
{
    public partial class atikToplamaOyunu : Form
    {
        private List<Atik> atiklar;             //atıkları tutacak liste yapısı
        private Atik simdikiAtik;

        
        private MetalAtik metal_Atik_Kutusu;
        private OrganikAtik organik_Atik_Kutusu;
        private KagitAtik Kagit_Atik_Kutusu;
        private CamAtik cam_Atik_Kutusu;

        public atikToplamaOyunu()
        {
            InitializeComponent();
        }

        private void NewGame()
        {
            organik_Atik_Kutusu = new OrganikAtik();         //yeni oyun için her bir atıktan nesne oluşturuluyor
            metal_Atik_Kutusu = new MetalAtik();
            cam_Atik_Kutusu = new CamAtik();
            Kagit_Atik_Kutusu = new KagitAtik();

            OrganikAtikBtn.Enabled = true;              //atık ekleme ve boşaltma butonları aktif
            OrganikAtikBosaltbtn.Enabled = true;
            OrganikAtikProgress.Value = 0;
            OrganikAtiklar.Items.Clear();

            CamAtikBtn.Enabled = true;
            CamAtikBosaltBtn.Enabled = true;
            CamAtikProgress.Value = 0;
            CamAtiklar.Items.Clear();

            KagitAtikBtn.Enabled = true;
            KagitAtikBosaltBtn.Enabled = true;
            KagitAtikprogress.Value = 0;
            KagitAtiklar.Items.Clear();

            MetalAtikBtn.Enabled = true;
            MetalAtikBosaltBtn.Enabled = true;
            MetalAtikProgress.Value = 0;
            MetalAtiklar.Items.Clear();

            PuanLbl.Text = "0";
            OyunSuresiLbl.Text = "60";

            YeniOyunBtn.Enabled = false;

            AtikListe(); 
            RastgeleAtik();

            timerGameTime.Enabled = true;
        }

        private void GameOver()      //oyun bittiğinde atık ve atik boşaltma butonlarını pasif hale getir
        {
            timerGameTime.Enabled = false;

            AtikImage.InitialImage = null;

            OrganikAtikBtn.Enabled = false;
            OrganikAtikBosaltbtn.Enabled = false;


            CamAtikBtn.Enabled = false;
            CamAtikBosaltBtn.Enabled = false;

            KagitAtikBtn.Enabled = false;
            KagitAtikBosaltBtn.Enabled = false;

            MetalAtikBtn.Enabled = false;
            MetalAtikBosaltBtn.Enabled = false;

            YeniOyunBtn.Enabled = true;              //yeni oyun butonu aktif 
        }

        private void ZamaniGoruntule(int sn)          
        {
            int şimdikiZaman = int.Parse(OyunSuresiLbl.Text);
            int ekZaman = şimdikiZaman + sn;

            if (ekZaman == 0)         //zaman sıfırlanırsa oyunu bitir
                GameOver();

            OyunSuresiLbl.Text = ekZaman.ToString();
        }

        private void AtikListe()        //atikların listesi
        {
            string resimYolu = Application.StartupPath + "\\Images\\";
            atiklar = new List<Atik>();
            atiklar.Add(new Atik(600, Image.FromFile(resimYolu + "camsise.jpg"), "Cam Şişe", AtikTipi.Cam));
            atiklar.Add(new Atik(250, Image.FromFile(resimYolu + "bardak1.jpg"), "Bardak", AtikTipi.Cam));
            atiklar.Add(new Atik(250, Image.FromFile(resimYolu + "gazete.jpg"), "Gazete", AtikTipi.Kagit));
            atiklar.Add(new Atik(200, Image.FromFile(resimYolu + "dergi.jpg"), "Dergi", AtikTipi.Kagit));
            atiklar.Add(new Atik(150, Image.FromFile(resimYolu + "domates.jpg"), "Domates", AtikTipi.Organik));
            atiklar.Add(new Atik(120, Image.FromFile(resimYolu + "salatalik.jpg"), "Salatalik", AtikTipi.Organik));
            atiklar.Add(new Atik(350, Image.FromFile(resimYolu + "kolakutusu.jpg"), "Kola Kutusu", AtikTipi.Metal));
            atiklar.Add(new Atik(350, Image.FromFile(resimYolu + "salcakutusu.jpg"), "Salça kutusu", AtikTipi.Metal));
        }

        private void RastgeleAtik()       //rasgele bir atık üretiliyor ve resmi görüntülüyor
        {
            Random random = new Random();
            int orderAtik = random.Next(0, 7);
            simdikiAtik = atiklar[orderAtik];
            AtikImage.Image = simdikiAtik.Image;
        }

        private void Puanla(int point)
        {
            int currentPoint = int.Parse(PuanLbl.Text);
            int newPoint = currentPoint + point;
            PuanLbl.Text = newPoint.ToString();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void timerOyunZamani_Tick(object sender, EventArgs e)
        {
            ZamaniGoruntule(-1);
        }

        private void btnAddOrganicAtik_Click(object sender, EventArgs e)
        {
            if (simdikiAtik.Tip == AtikTipi.Organik)                  //atik organik ise
            {
                if (organik_Atik_Kutusu.Ekle(simdikiAtik))            //organik atik kutusuna ekleniyor
                {
                    OrganikAtiklar.Items.Add(simdikiAtik.Isim + " (" + simdikiAtik.Hacim.ToString() + ")");
                    Puanla(simdikiAtik.Hacim);
                    OrganikAtikProgress.Value = organik_Atik_Kutusu.FullRate;
                    RastgeleAtik();
                }
            }
        }

        private void btnKagitAtikEkle_Click(object sender, EventArgs e)
        {
            if (simdikiAtik.Tip == AtikTipi.Kagit)                     //atik kağıt ise
            {
                if (Kagit_Atik_Kutusu.Ekle(simdikiAtik))              //kağıt kutusuna ekleniyor
                {
                    KagitAtiklar.Items.Add(simdikiAtik.Isim + " (" + simdikiAtik.Hacim.ToString() + ")");
                    Puanla(simdikiAtik.Hacim);
                    KagitAtikprogress.Value = Kagit_Atik_Kutusu.FullRate;
                    RastgeleAtik();
                }
            }
        }

        private void btnCamAtikEkle_Click(object sender, EventArgs e)
        {
            if (simdikiAtik.Tip == AtikTipi.Cam)                       //cam ise
            {
                if (cam_Atik_Kutusu.Ekle(simdikiAtik))                 //cam kutusuna ekleniyor
                {
                    CamAtiklar.Items.Add(simdikiAtik.Isim + " (" + simdikiAtik.Hacim.ToString() + ")");
                    Puanla(simdikiAtik.Hacim);
                    CamAtikProgress.Value = cam_Atik_Kutusu.FullRate;
                    RastgeleAtik();
                }
            }
        }

        private void btnMetalAtikEkle_Click(object sender, EventArgs e)
        {
            if (simdikiAtik.Tip == AtikTipi.Metal)                    //metal atik ise
            {
                if (metal_Atik_Kutusu.Ekle(simdikiAtik))               //metal kutusuna ekleniyor
                {
                    MetalAtiklar.Items.Add(simdikiAtik.Isim + " (" + simdikiAtik.Hacim.ToString() + ")");
                    Puanla(simdikiAtik.Hacim);
                    MetalAtikProgress.Value = metal_Atik_Kutusu.FullRate;
                    RastgeleAtik();
                }
            }
        }

        private void btnOrganikAtikBosalt_Click(object sender, EventArgs e)   //organik atık kutusu temizleniyor
        {
            if (organik_Atik_Kutusu.Temizle())
            {
                OrganikAtiklar.Items.Clear();
                OrganikAtikProgress.Value = 0;
                Puanla(organik_Atik_Kutusu.SkorTemizle);
                ZamaniGoruntule(3);
            }
        }

        private void btnKagitAtikBosalt_Click(object sender, EventArgs e)        //kağıt atık kutusu temizleniyor
        {
            if (Kagit_Atik_Kutusu.Temizle())
            {
                KagitAtiklar.Items.Clear();
                KagitAtikprogress.Value = 0;
                Puanla(Kagit_Atik_Kutusu.SkorTemizle);
                ZamaniGoruntule(3);
            }
        }

        private void btnCamAtikBosalt_Click(object sender, EventArgs e)             //cam atik kutusu temizleniyor
        {
            if (cam_Atik_Kutusu.Temizle())
            {
                CamAtiklar.Items.Clear();
                CamAtikProgress.Value = 0;
                Puanla(cam_Atik_Kutusu.SkorTemizle);
                ZamaniGoruntule(3);
            }
        }

        private void btnMetalAtikBosalt_Click(object sender, EventArgs e)     //metal atik kutusu temizleniyor
        {
            if (metal_Atik_Kutusu.Temizle())
            {
                MetalAtiklar.Items.Clear();
                MetalAtikProgress.Value = 0;
                Puanla(metal_Atik_Kutusu.SkorTemizle);
                ZamaniGoruntule(3);
            }
        }

      

       

        private void lstOrganikAtiklar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prgOrganikAtik_Click(object sender, EventArgs e)
        {

        }
    }
}
