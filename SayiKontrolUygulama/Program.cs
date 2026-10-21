using System;

namespace SayiKontrolUygulama
{
    class SayiIslemleri
    {
        public void Baslat()
        {
            string deger;
            do
            {
                deger = SayiGir();

                // Çıkış kontrolü
                if (deger.ToUpper() == "N")
                {
                    Console.WriteLine("Program sonlandırılıyor...");
                    break;
                }

                // Sayı mı değil mi kontrolü yapıyoruz
                if (SayiMiKontrolEt(deger, out int sayi))
                {
                    // Sayıysa tek mi çift mi olduğuna bakıyoruz
                    TekMiCiftMi(sayi);
                }
                else
                {
                    Console.WriteLine("Hatalı giriş, lütfen bir sayı girin.");
                }

            } while (true);
        }

        // kullanıcıdan veri alan fonksiyon
        private string SayiGir()
        {
            Console.Write("Sayı gir - çıkmak için 'N' / 'n' giriniz:");
            return Console.ReadLine();
        }

        // inputun sayı olup olmadığını kontrol eden fonksiyon
        private bool SayiMiKontrolEt(string girdi, out int sayi)
        {
            // int.TryParse başarılı olursa true, başarısız olursa false döner.
            // Ayrıca out parametresi ile dönüştürülen sayıyı dışarı aktarır.
            return int.TryParse(girdi, out sayi);
        }

        // inputun tek veya çift olduğunu ekrana yazan fonksiyon
        private void TekMiCiftMi(int sayi)
        {
            if (sayi % 2 == 0)
            {
                Console.WriteLine("Sayı çifttir.");
            }
            else
            {
                Console.WriteLine("Sayı tektir.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // SayiIslemleri sınıfından yeni bir nesne (object) üretiyoruz
            SayiIslemleri islem = new SayiIslemleri();

            // Nesnenin ana fonksiyonunu çağırarak programı başlatıyoruz
            islem.Baslat();
        }
    }
}
