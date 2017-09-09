using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public List<Musteri> MusteriListesi = new List<Musteri>();//ilki depo diğerleri müşteriler
        public List<Arac> AracListesi = new List<Arac>();//tüm araç isimleri ve kapasiteleri
        public List<Birey> ilkToplum = new List<Birey>();//ilki depo diğerleri müşteriler
        public List<Birey> yeniToplum = new List<Birey>();//ilki depo diğerleri müşteriler
       // StringBuilder sonucekrani = new StringBuilder();
        public int NesilSayisi = 200;//ardarda toplum dönüşümünü içerir nesil sayısı
        int BireySayisi = 300;//işlemlerdeki çözüm sayısıdır birey sayısı
        int ElitSayisi = 2;//en iyiler secılırken gerıye kalanlar ÇAPRAZLAMA ORANINI OLDUGU ICIN BU PARAMETREDE ONEMLI
        int MutasyonSayisi = 1;//burada mutasyona ugrayacak gen sayısı belırlenebılır..
        int MutasyonOranı = 1; //mutasyon oranını buradan duzenlenebılır..
        int GenSayisi;//musteri sayısına göre şekillenicek
       string anaharfler = "ABCDEFGHIJKLMNOPRSTUVYZ";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            Musteri depo = new Musteri("Depo", 29.4641132354736, 40.8027153015137, 350, 0);
            MusteriListesi.Add(depo);

            depo = new Musteri("A", 29.06643, 40.19116, 5200, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("B", 29.01328, 40.19894, 2300, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("C", 29.0501, 40.18619, 1800, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("D", 28.84832, 40.22656, 2750, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("E", 28.962, 40.22059, 1220, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("F", 29.00918, 40.19609, 4200, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("G", 29.10665, 40.19115, 2050, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("H", 29.09126, 40.17046, 950, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("I", 29.09699, 40.18604, 520, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("J", 32.83407, 39.84888, 1190, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("K", 29.08308, 40.19075, 3450, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("L", 29.8634187706934, 40.7323496298349, 2900, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("M", 29.8082548916264, 40.7339963127921, 1150, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("N", 29.9301094304608, 40.7751633867227, 1750, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("O", 29.8650654536506, 40.7669299719366, 2350, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("P", 27.19773, 38.4604, 5400, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("R", 29.07298, 40.19448, 3980, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("S", 28.96727, 41.04287, 2650, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("T", 27.19359, 38.46205, 1900, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("U", 27.19583, 38.46093, 3350, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("V", 27.15335, 38.4777, 2800, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("Y", 28.97223, 41.11768, 4200, 0);
            MusteriListesi.Add(depo);
            depo = new Musteri("Z", 30.89001, 40.31824, 1950, 0);
            MusteriListesi.Add(depo);

            Arac arac = new Arac("Mercedes-14670 ", 14670, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-9130  ", 9130, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-9130 ", 9130, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-9130  ", 9130, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-7860  ", 7860, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-7860  ", 7860, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-7860  ", 7860, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-7860  ", 7860, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-7860  ", 7860, false);
            AracListesi.Add(arac);
            arac = new Arac("Mercedes-1490  ", 1490, false);
            AracListesi.Add(arac);

            StringBuilder baslangic = new StringBuilder();
            baslangic.AppendLine("Adı - Enlem - Boylam - Talep Miktarı");
            for (int i = 0; i < MusteriListesi.Count; i++)
            {
                Musteri item = MusteriListesi[i];
                baslangic.AppendLine(String.Format("{0} - {1}  - {2}  - {3} - {4} ", i, item.Adi, item.Enlem, item.Boylam, item.SiparisMiktari));
            }
            baslangicdurumu.Text = baslangic.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sonucekrani = new StringBuilder();
            ilkToplum = ToplumOlustur();
            listBox1.Items.Clear();
            String sonucekraniyazisi = "İlk Toplum tüm bireyleri oluşturuldu.";
            //sonucekrani.AppendLine(String.Format("{0}", sonucekraniyazisi));
            listBox1.Items.Add(sonucekraniyazisi);
            //ResultText.Text = sonucekrani.ToString();

            //yeniToplum = ilkToplum;
            //sonucekraniyazisi = "İlk Toplum bireyleri işlem yapılab.";
            //sonucekrani.AppendLine(String.Format("{0}", sonucekraniyazisi));
            //ResultText.Text = sonucekrani.ToString();

            //her nesil için döngü gerçekleşecek ve döngünün en iyisi ekrana yazılacak

            // test amaçlı nesil bir defa denenecek 
       
            for (int i_nesil = 0; i_nesil < NesilSayisi; i_nesil++)
            {
               
                //her bireyin uygunluğu hesaplanacak
                foreach (Birey birey in ilkToplum)
                {
                    //List<Arac> bireyinAraclari = new List<Arac>();
                    //bireyinAraclari = AracListesi.ToList();

                    List<Arac> bireyinAraclari = AracListesi.CloneList().ToList();

                    //List<ICloneable> AracListesi = new List<ICloneable>();
                    //List<ICloneable> bireyinAraclari = new List<ICloneable>(AracListesi.Count);

                    //AracListesi.ForEach((item) =>
                    //{
                    //    bireyinAraclari.Add((ICloneable)item.Clone());
                    //});

                    //uygunluk hesaplanırken kromozomlar tek tek dolaşılarak hesaplanıcak
                    for (int i_kromozom = 0; i_kromozom < birey.Kromozom.Length; i_kromozom++)
                    {
                        //her kromozom bir müşteri depodan başlayıp her kromozoma ait müşteriyi uzaklığı hesaplanıcak, sonra bir sonraki müşteriye 
                        //giderken ki mesafe hesaplanıcak. Uzaklık dışında eldeki araç miktarı en son kaç tane kullanılmışsa ona göre değerlendirilicek
                        //örneğin bireyin tüm kromozomları dolaşılıp mesafeler ve ihtiyaç olan taşıma araç sayıları belirlendikten sonra
                        // puanlama yapılacak. bu puanlama uygun değerini temsil eder.
                        //puan hesaplanırken toplam ihtiyaç miktarını en çok yük alan araçı gönderirken rutun kaç tanesi yapabileceği tespit edilecek. Ardından 
                        //ikinci en çok yük alabilen aracın kaç tane yapabileceği tespit edilir ve tümünde sırasıyla kaç aracın devreye gireceği netleştiirilir.
                        // her aracın yapacağı mesafeler hesaplanarak toplam miktar uygunluk değeri olarak alınır. Böylece toplam miktar en az olan bizim için en iyi ruttur.
                        // örneğin toplam talep miktarı 3 araçla 4500 km yol gidilerek karşılayan bir rutlama ile 2 araçla 3800 km yol gidilebilecek şekilde daha iyi bir 
                        //rotalama yapılabilir. 

                        Char harf = birey.Kromozom[i_kromozom];
                        Char oncekiharf = birey.Kromozom[i_kromozom == 0 ? i_kromozom : i_kromozom - 1];
                        Musteri oncekiMusteri = MusteriListesi.Where(c => c.Adi == oncekiharf.ToString()).FirstOrDefault();
                        if (i_kromozom == 0)
                        {
                            oncekiMusteri = MusteriListesi[0];
                        }
                        Musteri suankiMusteri = MusteriListesi.Where(c => c.Adi == harf.ToString()).FirstOrDefault();

                        //önce araba kapasitesinin yeterliliği kontrol edilecek yetmezse yeni arac harekete başlayacak sonra kapastesi azaltılacak arabanın
                        int SiparisMiktari = suankiMusteri.SiparisMiktari;
                        //Arac sontrue = new Arac();
                        //sontrue = bireyinAraclari.Where(c => c.Kullanildimi == false).FirstOrDefault();
                        int siradakaracindexi = bireyinAraclari.FindIndex(c => c.Kullanildimi == false);
                        //siradakaracindexi += 1;
                        //if eğer var olan araç kapasitesi yeterli gelir mi kontrolu. Mesafe burası ile önceki nokta arası hesaplanır
                        try
                        {
                            if (bireyinAraclari[siradakaracindexi].Kapasite >= SiparisMiktari)
                            {
                                bireyinAraclari[siradakaracindexi].Kapasite -= SiparisMiktari;
                                birey.AraclarinGuzergahi += harf;
                            }
                            else
                            {
                                //burda yeterli gelmediğinde diğer araca geçilmiştir. Dolayısıyla mesafe depodan bu noktaya göre yapılır
                                bireyinAraclari[siradakaracindexi].Kullanildimi = true;
                                siradakaracindexi++;
                                bireyinAraclari[siradakaracindexi].Kapasite -= SiparisMiktari;
                                //araç değiştiriği için ceza 2000
                                birey.Uygunluk += 2000;
                                birey.AraclarinGuzergahi += " -- "+harf;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    
                        double aradakiMesafe = Geography.CalculateDistance(suankiMusteri.Enlem, suankiMusteri.Boylam, oncekiMusteri.Enlem, oncekiMusteri.Boylam);
                        birey.Uygunluk += (int)aradakiMesafe / 1000;
                        birey.ToplamYol += (int)aradakiMesafe / 1000;


                    }

                    birey.AraclarSirasi = bireyinAraclari;
                }
                //uygunluk hesaplamaları bitti en iyiler kontrol edilecek
                var minUygunluk = ilkToplum.Min(obj => obj.Uygunluk);
                Birey buneslineniyibireyi = ilkToplum.Where(obj => obj.Uygunluk == minUygunluk).FirstOrDefault();
                int KullanilanAracSayisi = buneslineniyibireyi.AraclarSirasi.FindIndex(c => c.Kullanildimi == false);
               // sonucekrani.AppendLine(String.Format("{0} Neslin bireylerinin uygunluk değeri hesaplandı.", i_nesil + 1));
               // sonucekrani.AppendLine(String.Format("{0} Neslin bireylerinin en iyi olan Birey \nKromozomu: {1}, \nUygunluk Değeri: {2}, \nKullandığı Araç Sayısı: {3}", i_nesil + 1, buneslineniyibireyi.Kromozom, buneslineniyibireyi.Uygunluk, KullanilanAracSayisi - 1));
                listBox1.Items.Add(String.Format("{0}. Neslin en iyi Bireyinin \nGüzergahı: {1}, \nToplam Yol: {2}, \nKullandığı Araç Sayısı: {3}", i_nesil + 1, buneslineniyibireyi.AraclarinGuzergahi, buneslineniyibireyi.ToplamYol, KullanilanAracSayisi + 1));
               // ResultText.Text = sonucekrani.ToString();

                yeniToplum = new List<Birey>();
                Birey b = (Birey)buneslineniyibireyi.Clone();
                //elitizm yapılıyor en iyi birey saklanıyor
                yeniToplum.Add(b);
                yeniToplum.Add(b);

                //çaprazlama ile yeni topumun kalan tüm elemanları oluşturuluyor.
                // Sıralamaya dayalı çaprazlama yapılmaktadır.
                Random rnd = new Random();
                for (int i_caprazlama = 0; i_caprazlama < BireySayisi - 2; i_caprazlama = i_caprazlama + 2)
                {
                    Birey caprazlama_ilkbirey = ilkToplum[rnd.Next(BireySayisi)];
                    Birey caprazlama_ikincibirey = ilkToplum[rnd.Next(BireySayisi)];
                      Birey caprazlama_ilkfinalist;
                      if (caprazlama_ilkbirey.Uygunluk < caprazlama_ikincibirey.Uygunluk)
                      {
                          caprazlama_ilkfinalist = caprazlama_ilkbirey;
                      }
                      else
                      {
                          caprazlama_ilkfinalist = caprazlama_ikincibirey;
                      }

                      Birey caprazlama_ucuncubirey = ilkToplum[rnd.Next(BireySayisi)];
                      Birey caprazlama_dortuncubirey = ilkToplum[rnd.Next(BireySayisi)];
                      Birey caprazlama_ikincifinalist;
                      if (caprazlama_ucuncubirey.Uygunluk < caprazlama_dortuncubirey.Uygunluk)
                      {
                          caprazlama_ikincifinalist = caprazlama_ucuncubirey;
                      }
                      else
                      {
                          caprazlama_ikincifinalist = caprazlama_dortuncubirey;
                      }

                      int caprazlanacakKromozomBogumu = rnd.Next(1, anaharfler.Length-1);

                      String ilkparcailk = caprazlama_ilkfinalist.Kromozom.Substring(0, caprazlanacakKromozomBogumu);
                      String kalanparcailk = caprazlama_ikincifinalist.Kromozom;
                      for (int i_caprazlama_kromozom = 0; i_caprazlama_kromozom < kalanparcailk.Length; i_caprazlama_kromozom++)
                      {
                          Char harf = kalanparcailk[i_caprazlama_kromozom];
                          if (!ilkparcailk.Contains(harf))
                          {
                              ilkparcailk += harf.ToString();
                          }
                      }

                      caprazlama_ilkfinalist.Kromozom = ilkparcailk;
                      caprazlama_ilkfinalist.Uygunluk = 0;
                      caprazlama_ilkfinalist.ToplamYol = 0;
                       b = (Birey)caprazlama_ilkfinalist.Clone();
                      yeniToplum.Add(b);

                      String ilkparcaikinci = caprazlama_ikincifinalist.Kromozom.Substring(0, caprazlanacakKromozomBogumu);
                      String kalanparcaikinci = caprazlama_ilkfinalist.Kromozom;
                      for (int i_caprazlama_kromozom = 0; i_caprazlama_kromozom < kalanparcaikinci.Length; i_caprazlama_kromozom++)
                      {
                          Char harf = kalanparcaikinci[i_caprazlama_kromozom];
                          if (!ilkparcaikinci.Contains(harf))
                          {
                              ilkparcaikinci += harf.ToString();
                          }
                      }

                      caprazlama_ikincifinalist.Kromozom = ilkparcaikinci;
                      caprazlama_ikincifinalist.Uygunluk = 0;
                      caprazlama_ikincifinalist.ToplamYol = 0;

                      b = (Birey)caprazlama_ikincifinalist.Clone();
                      yeniToplum.Add(b);

                }

                //mutasyonla bir birey kromozomları yer değiştiriliyor
                int mutasyonluBirey = rnd.Next(BireySayisi);
                String  mutasyon_bireyin_kromozomu = yeniToplum[mutasyonluBirey].Kromozom;
                int mutasyonaugrayacakbirinciKromozom_int=rnd.Next(1, anaharfler.Length-1);
                int mutasyonaugrayacakikinciKromozom_int = rnd.Next(1, anaharfler.Length - 1);
                //Char mutasyonaugrayacakbirinciKromozom = mutasyon_bireyin_kromozomu[mutasyonaugrayacakbirinciKromozom_int];
                //Char mutasyonaugrayacakikinciKromozom = mutasyon_bireyin_kromozomu[mutasyonaugrayacakikinciKromozom_int];
                yeniToplum[mutasyonluBirey].Kromozom = Geography.SwapCharacters(yeniToplum[mutasyonluBirey].Kromozom, mutasyonaugrayacakbirinciKromozom_int, mutasyonaugrayacakikinciKromozom_int);
               // yeniToplum[mutasyonluBirey].Kromozom= yeniToplum[mutasyonluBirey].Kromozom.Replace(mutasyonaugrayacakbirinciKromozom, mutasyonaugrayacakikinciKromozom);

             
                ilkToplum = yeniToplum.CloneList().ToList();

                for (int i = 0; i < ilkToplum.Count; i++)
                {
                    ilkToplum[i].Uygunluk = 0;
                    ilkToplum[i].ToplamYol = 0;
                    ilkToplum[i].AraclarinGuzergahi = "";
                }
 
            }
        }

        public List<Birey> ToplumOlustur()
        {
            List<Birey> toplum = new List<Birey>();
           
            Random rastgele = new Random();
            while (toplum.Count < BireySayisi)
            {
                string harflerharfler = anaharfler;
                Birey islemyapilacakBirey = new Birey("","", 0,0, new List<Arac>());
                //islemyapilacakBirey= toplum[toplum.Count];
                while (islemyapilacakBirey.Kromozom.Length < anaharfler.Length)
                {
                    int rastint = rastgele.Next(harflerharfler.Length);
                    Char harf = harflerharfler[rastint];

                    if (!islemyapilacakBirey.Kromozom.Contains(harf))
                    {
                        islemyapilacakBirey.Kromozom += harf;
                        harflerharfler = harflerharfler.Remove(rastint, 1);
                    }
                }

                toplum.Add(islemyapilacakBirey);

            }
            return toplum;
        }

    }


    internal static class Extensions
    {
        public static IList<T> CloneList<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
    }

}
