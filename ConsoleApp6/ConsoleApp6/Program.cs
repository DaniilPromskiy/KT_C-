using System;

public class Light
{
    public bool IsTurnedOn { get; private set; }
    public int Brightness { get; private set; } 
    public string Color { get; private set; }

    public Light()
    {
        IsTurnedOn = false;
        Brightness = 0;
        Color = "White";
    }

    public void SwitchLight()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void ChangeBrightness(int brightness)
    {
        Brightness = Math.Clamp(brightness, 0, 100);
    }

    public void ChangeColor(string color)
    {
        Color = color;
    }

    public override string ToString()
    {
        return $"Light - On: {IsTurnedOn}, Brightness: {Brightness}, Color: {Color}";
    }
}

public class TV
{
    public bool IsTurnedOn { get; private set; }
    public string Program { get; private set; }

    public TV()
    {
        IsTurnedOn = false;
        Program = "None";
    }

    public void SwitchTV()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void TurnOnProgram(string program)
    {
        Program = program;
    }

    public override string ToString()
    {
        return $"TV - On: {IsTurnedOn}, Program: {Program}";
    }
}

public class AirConditioner
{
    public bool IsTurnedOn { get; private set; }
    public int Temperature { get; private set; } 

    public AirConditioner()
    {
        IsTurnedOn = false;
        Temperature = 24; 
    }

    public void Switch()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void SetTemperature(int temperature)
    {
        Temperature = temperature;
    }

    public override string ToString()
    {
        return $"AirConditioner - On: {IsTurnedOn}, Temperature: {Temperature}°C";
    }
}

public class MusicStation
{
    public bool IsTurnedOn { get; private set; }
    public string Music { get; private set; }

    public MusicStation()
    {
        IsTurnedOn = false;
        Music = "None";
    }

    public void Switch()
    {
        IsTurnedOn = !IsTurnedOn;
    }

    public void SetMusic(string music)
    {
        Music = music;
    }

    public override string ToString()
    {
        return $"MusicStation - On: {IsTurnedOn}, Music: {Music}";
    }
}

public class SmartHome
{
    private Light light;
    private TV tv;
    private AirConditioner airConditioner;
    private MusicStation musicStation;

    public SmartHome()
    {
        light = new Light();
        tv = new TV();
        airConditioner = new AirConditioner();
        musicStation = new MusicStation();
    }

    public void SetUpHome(string mode)
    {
        switch (mode.ToLower())
        {
            case "night":
                light.SwitchLight(); 
                tv.SwitchTV(); 
                airConditioner.Switch(); 
                airConditioner.SetTemperature(20); 
                musicStation.Switch(); 
                musicStation.SetMusic("Lofi Hip Hop");
                break;

            case "party":
                light.SwitchLight(); 
                light.ChangeBrightness(100); 
                light.ChangeColor("Multicolor");
                tv.SwitchTV(); 
                tv.TurnOnProgram("Party Channel");
                airConditioner.Switch(); 
                musicStation.Switch(); 
                musicStation.SetMusic("Party Hits");
                break;

            case "good morning":
                light.SwitchLight(); 
                light.ChangeBrightness(80);
                light.ChangeColor("Warm White");
                tv.SwitchTV(); 
                airConditioner.Switch(); 
                musicStation.Switch(); 
                musicStation.SetMusic("Morning Jazz");
                break;

            case "leaving":
                light.SwitchLight();
                tv.SwitchTV(); 
                airConditioner.Switch(); 
                musicStation.Switch(); 
                break;

            case "home alone":
                light.SwitchLight(); 
                light.ChangeBrightness(50);
                tv.SwitchTV(); 
                tv.TurnOnProgram("Movie Channel");
                airConditioner.Switch(); 
                airConditioner.SetTemperature(22);
                musicStation.Switch(); 
                musicStation.SetMusic("Chill Vibes");
                break;

            default:
                Console.WriteLine("Unknown mode. Please select a valid mode.");
                return;
        }

        Console.WriteLine(light);
        Console.WriteLine(tv);
        Console.WriteLine(airConditioner);
        Console.WriteLine(musicStation);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SmartHome smartHome = new SmartHome();

        Console.WriteLine("Настройка умного дома на режим 'Ночной':");
        smartHome.SetUpHome("night");

        Console.WriteLine("\nНастройка умного дома на режим 'Вечеринка':");
        smartHome.SetUpHome("party");

        Console.WriteLine("\nНастройка умного дома на режим 'Доброе утро':");
        smartHome.SetUpHome("good morning");

        Console.WriteLine("\nНастройка умного дома на режим 'Ухожу':");
        smartHome.SetUpHome("leaving");

        Console.WriteLine("\nНастройка умного дома на режим 'Один дома':");
        smartHome.SetUpHome("home alone");
    }
}