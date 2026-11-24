using System;
using System.Collections.Generic;

namespace NYPLabOdev
{
    enum CihazTuru
    {
        Lamba,
        Klima,
        GuvenlikSistemi
    }

    class Cihaz
    {
        public int Kimlik { get; set; }
        public string Ad { get; set; }
        public CihazTuru Tur { get; set; }
        public bool AcikMi { get; private set; }

        public Cihaz(int kimlik, string ad, CihazTuru tur)
        {
            Kimlik = kimlik;
            Ad = ad;
            Tur = tur;
            // Yeni cihaz kapalı başlar.
            AcikMi = false;
        }

        public void Ac()
        {
            AcikMi = true;
        }

        public void Kapat()
        {
            // Yeni cihaz kapalı başlar.
            AcikMi = false;
        }

        public void BilgileriGoster()
        {
            string durum = AcikMi ? "Açık" : "Kapalı";
            Console.WriteLine($"Kimlik: {Kimlik} | Ad: {Ad} | Tür: {Tur} | Durum: {durum}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cihaz> cihazlar = new List<Cihaz>
            {
                new Cihaz(1, "Salon Lambası", CihazTuru.Lamba),
                new Cihaz(2, "Oda Kliması", CihazTuru.Klima),
                new Cihaz(3, "Kapı Güvenliği", CihazTuru.GuvenlikSistemi)
            };

            while (true)
            {
                Console.WriteLine("\n--- Akıllı Ev Cihaz Yönetimi ---");
                Console.WriteLine("1 - Cihazları Listele");
                Console.WriteLine("2 - Yeni Cihaz Ekle");
                Console.WriteLine("3 - Cihaz Aç");
                Console.WriteLine("4 - Cihaz Kapat");
                Console.WriteLine("0 - Çıkış");
                Console.Write("Seçiminiz: ");

                var secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        foreach (Cihaz cihaz in cihazlar)
                        {
                            cihaz.BilgileriGoster();
                        }
                        break;

                    case "2":
                        Console.Write("Yeni cihazın kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int kimlik))
                        {
                            Console.WriteLine("Kimlik tam sayı olmalıdır.");
                            break;
                        }

                        // Aynı kimlik listedeyse yeni cihaz eklenmez.
                        if (cihazlar.Exists(cihaz => cihaz.Kimlik == kimlik))
                        {
                            Console.WriteLine("Bu kimliğe sahip bir cihaz zaten var.");
                            break;
                        }

                        Console.Write("Cihaz adı: ");
                        var ad = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(ad))
                        {
                            Console.WriteLine("Cihaz adı boş olamaz.");
                            break;
                        }

                        Console.Write("Tür seçin (1 - Lamba, 2 - Klima, 3 - Güvenlik Sistemi): ");
                        CihazTuru tur;
                        switch (Console.ReadLine())
                        {
                            case "1": tur = CihazTuru.Lamba; break;
                            case "2": tur = CihazTuru.Klima; break;
                            case "3": tur = CihazTuru.GuvenlikSistemi; break;
                            default:
                                Console.WriteLine("Geçersiz cihaz türü.");
                                continue;
                        }

                        cihazlar.Add(new Cihaz(kimlik, ad.Trim(), tur));
                        Console.WriteLine("Cihaz eklendi.");
                        break;

                    case "3":
                    case "4":
                        // Açma ve kapatma için önce aynı listede kimlik aranır.
                        Console.Write("Cihaz kimliği: ");
                        if (!int.TryParse(Console.ReadLine(), out int arananKimlik))
                        {
                            Console.WriteLine("Kimlik tam sayı olmalıdır.");
                            break;
                        }

                        var bulunanCihaz = cihazlar.Find(cihaz => cihaz.Kimlik == arananKimlik);
                        if (bulunanCihaz == null)
                        {
                            Console.WriteLine("Bu kimliğe sahip bir cihaz bulunamadı.");
                            break;
                        }

                        if (secim == "3")
                            bulunanCihaz.Ac();
                        else
                            bulunanCihaz.Kapat();

                        bulunanCihaz.BilgileriGoster();
                        break;

                    case null:
                    case "0":
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }
    }
}
