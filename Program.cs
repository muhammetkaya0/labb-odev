namespace ArabaMotorOdev
{
    class Motor
    {
        public string Model { get; set; }
        public int BeygirGucu { get; set; }

        public Motor(string model, int beygirGucu)
        {
            Model = model;
            BeygirGucu = beygirGucu;
        }

        public void Calistir()
        {
            Console.WriteLine($"{Model} ({BeygirGucu} HP) motor çalıştırıldı.");
        }
    }

    class Araba
    {
        public string Marka { get; set; }
        public Motor Motor { get; private set; }

        public Araba(string marka, Motor motor)
        {
            Marka = marka;
            Motor = motor;
        }

        public void Calistir()
        {
            Console.WriteLine($"{Marka} marka araba çalıştırılıyor...");
            Motor.Calistir();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Motor dizelMotor = new Motor("1.6 TDI", 115);
            Araba araba1 = new Araba("Volkswagen", dizelMotor);

            araba1.Calistir();
        }
    }
}
