using System;			// Code File Lab12.cs
public static class VehicleDemo
{
    public static void Main()
    {
        int numDs, maxSpeed;
        int vehicleID;
        string carType;

        Car richRide = new Car(12345, 250,1 , "Jaguar");
        Boat speedBoat = new Boat(54321, 30, 8, "Outboard Marine");
        Plane Aplane = new Plane(21245, 400, 2, "Boeing");

        // input a 5 digit vehicle identification number for the car
        do
        {
            Console.Write("Enter a 5-digit vehicle identification number => ");
            vehicleID = Convert.ToInt32(Console.ReadLine());
        } while ((vehicleID < 10000) || (vehicleID > 99999));
        richRide.VIN = vehicleID;

        // input the make of the car
        Console.Write("Enter the make of the car => ");
        carType = Console.ReadLine();
        richRide.Make = carType;

        // input the number of doors for the car
        do
        {
            Console.Write("Enter the number of doors for the car => ");
            numDs = Convert.ToInt32(Console.ReadLine());
        } while (numDs <= 0);
        richRide.NumDoors = numDs;

        // input the top speed of the car
        do
        {
            Console.Write("Enter the top speed of the car => ");
            maxSpeed = Convert.ToInt32(Console.ReadLine());
        } while (maxSpeed <= 0);
        richRide.TopSpeed = maxSpeed;

        // print out the information for the car
        Console.WriteLine(richRide);
        // Have the car sound its horn
        Console.WriteLine("The car goes " + richRide.SoundHorn());
        // print how the car operates
        Console.WriteLine(richRide.Operate());

        // print out the information for the boat
        Console.WriteLine(speedBoat);
        // Have the boat sound its horn
        Console.WriteLine("The boat goes " + speedBoat.SoundHorn());
        // print how the boat operates
        Console.WriteLine(speedBoat.Operate());

        // print out the information for the plane
        Console.WriteLine(Aplane);
        // Have the plane sound its horn
        Console.WriteLine("The boat goes " + Aplane.SoundHorn());
        // print how the plane operates
        Console.WriteLine(Aplane.Operate());
        Console.WriteLine("Its make is {0}", richRide.Make);

        Console.ReadLine();
    }
}