using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singleton;
using AbstractFactory;
using Builder;
using Adapter;
using Decorator;
using Facade;
using System.Collections;
using Iterator;
using Observer;
using Visitor;

namespace DesignPatternsClass
{
    class Program
    {
            static void Main(string[] args)
            {
                string myChoice;

                do

                {
                    // Print A Menu
                    Console.WriteLine("Running Classwork\n");

                    Console.WriteLine("1 - SingletonPatternDemo");
                    Console.WriteLine("2 - AbstractFactoryPatternDemo");
                    Console.WriteLine("3 - BuilderPatternDemo");
                    Console.WriteLine("4 - FacadePatternDemo");
                    Console.WriteLine("5 - IteratorPatternDemo");
                    Console.WriteLine("6 - IteratorPatternDemo2");
                    Console.WriteLine("7 - ObserverPatternDemo");
                    Console.WriteLine("8 - VisitorPatternDemo");
                    Console.WriteLine("Q - Quit\n");

                    Console.WriteLine("Choice (1 - 8 or Q): ");

                    // Retrieve the user's choice
                    myChoice = Console.ReadLine();

                    // Make a decision based on the user's choice
                    switch (myChoice)
                    {
                        case "1":
                            Console.WriteLine("You Wish to run SingletonPatternDemo");
                            SingletonPatternDemo();
                            break;
                        case "2":
                            Console.WriteLine("You wish to run AbstractFactoryPatternDemo");
                            AbstractFactoryPatternDemo();
                            break;
                        case "3":
                            Console.WriteLine("You Wish to run BuilderPatternDemo");
                            BuilderPatternDemo();
                            break;
                        case "4":
                            Console.WriteLine("You Wish to Run FacadePatternDemo");
                            FacadePatternDemo();
                            break;
                        case "5":
                            Console.WriteLine("You Wish to Run IteratorPatternDemo");
                            IteratorPatternDemo();
                            break;
                        case "6":
                            Console.WriteLine("You Wish to Run IteratorPatternDemo2");
                           IteratorPatternDemo2();
                           break;
                       case "7":
                            Console.WriteLine("You Wish to Run ObserverPatternDemo");
                           ObserverPatternDemo();
                           break;
                        case "8":
                           Console.WriteLine("You Wish to Run VisitorPatternDemo");
                           VisitorPatternDemo();
                           break;
                       case "Q":
                           case "q":
                           Console.WriteLine("Bye.");
                           break;
                        default:
                           Console.WriteLine("{0} is not a valid choice", myChoice);
                           break;
                    }

                    // Pause to allow the user to see the results
                    Console.Write("press Enter key to continue...");
                    Console.ReadLine();
                    Console.WriteLine();
                } while (myChoice != "Q" && myChoice != "q"); // Keep going until the user wants to quit
            }

        

        private static void VisitorPatternDemo()
        {
            IWheel wheel = new WideWheel(24);
            wheel.AcceptVisitor(new WheelDiagnostics());
            wheel.AcceptVisitor(new WheelInventory());
        }

        private static void ObserverPatternDemo()
        {
            Speedometer mySpeedometer = new Speedometer();
            SpeedMonitor monitor = new SpeedMonitor(mySpeedometer);
            GearBox auto = new GearBox(mySpeedometer);

            mySpeedometer.CurrentSpeed = 10;
            mySpeedometer.CurrentSpeed = 20;
            mySpeedometer.CurrentSpeed = 25;
            mySpeedometer.CurrentSpeed = 30;
            mySpeedometer.CurrentSpeed = 40;
            
        }
        private static void IteratorPatternDemo2()
        {
            Console.WriteLine("==== Road Bikes ====");
            RoadBikeRange roadRange = new RoadBikeRange();
            foreach (IBicycle bicycle in roadRange.Range)
            {
                Console.WriteLine(bicycle);
            }

            Console.WriteLine("==== Mountain Bikes ===");
            MountainBikeRange mountainRange = new MountainBikeRange();
            foreach (IBicycle bicycle in mountainRange.Range)
            {
                Console.WriteLine(bicycle);
            }
        }
        private static void IteratorPatternDemo()
        {
            Console.WriteLine("==== Road Bikes ====");
            RoadBikeRange roadRange = new RoadBikeRange();
            PrintIterator(roadRange.GetEnumerator());

            Console.WriteLine("==== Mountain Bikes ===");
            MountainBikeRange mountainRange = new MountainBikeRange();
            PrintIterator(mountainRange.GetEnumerator());
        }
        private static void PrintIterator(IEnumerator iter)
        {
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
            }
        }
        private static void SingletonPatternDemo()
        {
            SerialNumberGenerator generator = SerialNumberGenerator.Instance;

            Console.WriteLine("next serial: " + generator.NextSerial);
            Console.WriteLine("next serial: " + generator.NextSerial);
            Console.WriteLine("next serial: " + generator.NextSerial);
            Console.WriteLine("next serial: " + generator.NextSerial);
        }

        private static void AbstractFactoryPatternDemo()
        {
            string whatToMake = "roadbike";
            AbstractBikeFactory factory = null;

            if(whatToMake.Equals("road bike"))
            {
                factory = new RoadBikeFactory();
            }
            else
            {
                factory = new MountainBikeFactory();
            }

            // Create the bike parts
            IBikeFrame bikeFrame = factory.CreateBikeFrame();
            IBikeSeat bikeSeat = factory.CreateBikeSeat();

            // Show what we created
            Console.WriteLine(bikeFrame.BikeFrameParts);
            Console.WriteLine(bikeSeat.BikeSeatParts);
        }

        private static void BuilderPatternDemo()
        {
            AbstractMountainBike mountainBike = new DownHill(new WideWheel(24), BikeColor.Green);
            BikeBuilder builder = new MountainBikeBuilder(mountainBike);
            BikeDirector director = new MountainBikeDirector();
            IBicycle bicycle = director.Build(builder);
            Console.WriteLine(bicycle);
        }

        private static void AdapterPatternDemo()
        {
            IList<IWheel> wheels = new List<IWheel>();
            wheels.Add(new NarrowWheel(24));
            wheels.Add(new NarrowWheel(20));
            wheels.Add(new WideWheel(24));

            UltraWheel ultraWheel = new UltraWheel(22);
            wheels.Add(new UltraWheelAdapter(ultraWheel));

            foreach(IWheel wheel in wheels)
            {
                Console.WriteLine(wheel);
            }
        }

        private static void DecoratorPatternDemo()
        {
            IBicycle myTourBike = new Touring(new NarrowWheel(24), BikeColor.Blue);
            Console.WriteLine(myTourBike);

            myTourBike = new GoldFrameBike(myTourBike);
            Console.WriteLine(myTourBike);

            myTourBike = new CustomGripBike(myTourBike);
            Console.WriteLine(myTourBike);


        }

        private static void FacadePatternDemo()
        {
            BikeFacade facade = new BikeFacade();
            facade.PrepareForSale(new DownHill(new WideWheel(20), BikeColor.Red));
        }
    }
}
