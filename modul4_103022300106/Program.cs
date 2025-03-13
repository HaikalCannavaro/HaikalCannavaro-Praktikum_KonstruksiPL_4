class KodeProduk
{
    private String[] produkElektronik= { "Laptop", "Smartphone", "Tablet", "Headset", "Keyboard", "Mouse", "Printer", "Monitor", "Smartwatch", "Kamera"};
    private String[] kodeProduk = { "E100", "E101", "E102", "E103", "E104", "E105", "E106", "E107", "E108" , "E109"};
    
    public string getKodeProduk(String produk)
    {
        for (int i = 0; i < produkElektronik.Length; i++) 
        { 
            if (produkElektronik[i] == produk)
            {
                return kodeProduk[i];
            }
        }
        return "Produk tidak ada";
    } 
}

class FanLaptop
{
    public enum State { Quiet, Balance, Performance, Turbo};
    public enum Trigger { ModeUp, ModeDown, TurboShortcut};
    private State state;

    class changeMode 
    {
        public State firstState;
        public Trigger trigger;
        public State lastState;

        public changeMode(State firstState, Trigger trigger, State lastState) 
        {
            this.firstState = firstState;
            this.trigger = trigger;
            this.lastState = lastState;
        }

    }

    private changeMode[] changes =
    {
        new changeMode( State.Quiet, Trigger.ModeUp, State.Balance),
        new changeMode(State.Balance, Trigger.ModeUp, State.Performance),
        new changeMode(State.Performance, Trigger.ModeUp, State.Turbo),
        new changeMode(State.Turbo, Trigger.ModeDown, State.Performance),
        new changeMode(State.Performance, Trigger.ModeDown, State.Balance),
        new changeMode (State.Balance, Trigger.ModeDown, State.Quiet),
        new changeMode(State.Quiet, Trigger.TurboShortcut, State.Turbo),
        new changeMode(State.Turbo, Trigger.TurboShortcut, State.Quiet)
    };

    public String GetNextState(State firstState, Trigger trigger) 
    {
        for (int i = 0; i < changes.Length; i++)
        {
            if (firstState == changes[i].firstState && trigger == changes[i].trigger)
            {
                return "Fan " + firstState + " berubah menjadi " + changes[i].lastState;
            }
        }
        return "Fan tetap" + firstState;
    }
}
class Program
{
    static void Main(string[] args)
    {
        KodeProduk kodeProduk = new KodeProduk();
        String kodeProdukVar = Console.ReadLine();  
        Console.WriteLine(kodeProduk.getKodeProduk(kodeProdukVar));

        FanLaptop fanLaptop = new FanLaptop();  
        Console.WriteLine("Masukkan state awal: ");
        string stateAwal = Console.ReadLine();
        Console.WriteLine("Masukkan triger: ");
        string trigger = Console.ReadLine();
        FanLaptop.State state = (FanLaptop.State)Enum.Parse(typeof(FanLaptop.State), stateAwal);
        FanLaptop.Trigger triggerEnum = (FanLaptop.Trigger)Enum.Parse(typeof(FanLaptop.Trigger), trigger);
        Console.WriteLine(fanLaptop.GetNextState(state, triggerEnum));
    }
}