// Base Class - Vehicle			// Code File Lab12_2.cs
public abstract class Vehicle
{
    protected int vin;
    protected int topSpeed;

    // two argument constructor
    public Vehicle(int idNum, int speed)
    {
        VIN = idNum;
        TopSpeed = speed;
    }
    // Property defined for protected vin variable
    public int VIN
    {
        set
        {
            if (value >= 10000 && value <= 100000)
                vin = value;
            else
                vin = 0;
        }
        get
        {
            return vin;
        }
    }
    // Property defined for protected topSpeed variable
    public int TopSpeed
    {
        set
        {
            if (value >= 0)
                topSpeed = value;
            else
                topSpeed = 0;
        }
        get
        {
            return topSpeed;
        }
    }
    // Virutal method to Sound the horn
    public virtual string SoundHorn()
    {
        return "Beeeeeeeeep";
    }
    // Abstract method for derived classes to override
    public abstract string Operate();
}

// Derived Class - Car
public abstract class Car : Vehicle
{
    private int numDoors;
    private string make;

    // no argument constructor
    public Car() : base(0, 0)
    {
        numDoors = 0;
        make = " ";
    }
    // four argument constructor (two for Car and two for Vehicle)
    public Car(int vid, int maxSp, int numD, string typeCar) : base(vid, maxSp)
    {
        numDoors = numD;
        make = typeCar;
    }
    // Property defined for private numDoors variable
    public int NumDoors
    {
        set
        {
            if (value >= 0)
                numDoors = value;
            else
                numDoors = 0;
        }
        get
        {
            return numDoors;
        }
    }
    // Property defined for private make variable
    public string Make
    {
        set
        {
            make = value;
        }
        get
        {
            return make;
        }
    }
    // Override the ToString method from Object
    public override string ToString()
    {
        string output;
        output = "\nThis vehicle is a car\n";
        output += "VIN: " + vin + "\n";
        output += "Make: " + make + "\n";
        output += "Number of Doors: " + numDoors + "\n";
        output += "Top Speed:" + topSpeed + " kph";
        return output;
    }
    // Override the virtual method SoundHorn from Vehicle
    public override string SoundHorn()
    {
        return "Hoooooooonk";
    }
    // Override the abstract method Operate from Vehicle
    public override string Operate()
    {
        return "It drives on the road";
    }
}

// Derived Class - Boat
public class Boat : Vehicle
{
    private int numSeats;
    private string motorType;

    // four argument constructor (two for Boat and two for Vehicle)
    public Boat(int vid, int maxSp, int numS, string mType) : base(vid, maxSp)
    {
        numSeats = numS;
        motorType = mType;
    }
    // Override the ToString method from Object
    public override string ToString()
    {
        string output;
        output = "\nThis vehicle is a boat\n";
        output += "VIN: " + vin + "\n";
        output += "Type of motor: " + motorType + "\n";
        output += "Number of Seats: " + numSeats + "\n";
        output += "Top Speed:" + topSpeed + " knots";
        return output;
    }
    public override string SoundHorn()
    {
        return " Howoooooga";
    }
    // Override the abstract method Operate from Vehicle
    public override string Operate()
    {
        return "It moves through the water";
    }
    }
public class Plane : Vehicle
{
    private int numEngines;
    private string planeMaker;

    // four argument constructor (two for Car and two for Vehicle)
    public Plane(int vid, int maxSp, int numD, string typeCar) : base(vid, maxSp)
    {
        numEngines = numD;
        planeMaker = typeCar;
    }
    // Override the ToString method from Object
    public override string ToString()
    {
        string output;
        output = "\nThis vehicle is a plane\n";
        output += "VIN: " + vin + "\n";
        output += "Type of plane: " + planeMaker + "\n";
        output += "Number of engines: " + numEngines + "\n";
        output += "Top Speed:" + topSpeed + " knots";
        return output;
    }
    // Override the abstract method Operate from Vehicle
    public override string Operate()
    {
        return "It flies through the air";
    }
    // Override the virtual method SoundHorn from Vehicle
    public override string SoundHorn()
    {
        return "Whoooooosh";
    }

}

