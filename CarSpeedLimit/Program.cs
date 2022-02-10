using System;

namespace CarSpeedLimit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Objects
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();

            //Variables
            int speedLimit = 0;
            string make = "";
            string model = "";
            int speed = 0;
            int demerits = 0;
            string message = "";


            Console.Write("Please enter the Speed Limit: ");
            speedLimit = Convert.ToInt32(Console.ReadLine());

            //Car 1 information
            Console.WriteLine("\nPlease Enter the following information for car 1");

            car1.Make = car1.getMake(make);

            car1.Model = car1.getModel(model);

            car1.Speed = car1.getSpeed(speed);

            car1.Demerits = car1.calcDemerits(demerits, speedLimit);

            car1.Message = car1.getMessage(car1.Demerits, car1.Speed, speedLimit, message);

            //Car 2 information
            Console.WriteLine("\nPlease Enter the following information for car 2");

            car2.Make = car2.getMake(make);

            car2.Model = car2.getModel(model);

            car2.Speed = car2.getSpeed(speed);

            car2.Demerits = car2.calcDemerits(demerits, speedLimit);

            car2.Message = car2.getMessage(car2.Demerits, car2.Speed, speedLimit, message);

            //Car 3 information
            Console.WriteLine("\nPlease Enter the following information for car 3");

            car3.Make = car3.getMake(make);

            car3.Model = car3.getModel(model);

            car3.Speed = car3.getSpeed(speed);

            car3.Demerits = car3.calcDemerits(demerits, speedLimit);

            car3.Message = car3.getMessage(car3.Demerits, car3.Speed, speedLimit, message);

            //Display speed limit and information from car 1, car 2, and car 3
            Console.WriteLine("\nSpeed Limit: " + speedLimit + "mph\n");

            car1.Display();
            car2.Display();
            car3.Display();

            //Console.WriteLine("Speed Limit: " + speedLimit + "mph");

        }
    }
    

    public class Car
    {
        //Attributes
        private string make;
        private string model;
        private int speed;
        private int demerits;
        private string message;

        //Constructor
        public Car()
        {
            make = "";
            model = "";
            speed = 0;
        }

        //Getters and Setters
        public string Make
        {
            get => make;
            set => make = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }
        public int Speed
        {
            get => speed;
            set => speed = value;
        }

        public int Demerits
        {
            get => demerits;
            set => demerits = value;
        }

        public string Message
        {
            get => message;
            set => message = value;
        }

        //Functions
        public string getMake(string ma)
        {
            Console.Write("\nEnter the make: ");
            ma = Console.ReadLine();
            return ma;
        }

        public string getModel(string mo)
        {
            Console.Write("\nEnter the model: ");
            mo = Console.ReadLine();
            return mo;
        }

        public int getSpeed(int s)
        {
            Console.Write("\nEnter the speed: ");
            s = Convert.ToInt32(Console.ReadLine());
            return s;
        }

        //Calculates how many demerits the car will receive, if it's more than ten, display '<LICENSE SUSPENDED>'
        public int calcDemerits(int d, int sL) //d = demerits, sL = speedLimit
        {
            d = ((Speed - sL) - ((Speed - sL) % 5)) / 5;
            if (d == 0)
            {
                d = 1;
            }
            else if (d > 10)
            {
                d = 10;
            }

            return d;
        }

        //Displays how many demerits the car received, if it's ten or more, display '<LICENSE SUSPENDED>'
        public string getMessage(int d, int s, int sL, string m) //d = demerits, s = speed, sL = speedLimit, m = message
        {
            if (s > sL)
            {
                d = calcDemerits(d, sL);

                if (d >= 10)
                {
                    m = d + " demerits <LICENSE SUSPENDED>";
                }
                else if (d == 1)
                {
                    m = d + " demerit";
                }
                else
                {
                    m = d + " demerits";
                }
            }
            else
            {
                m = "OK";
            }
            return m;
        }

        //the function will display the make, model, speed of the car along with how many demerits the car received
        public void Display()
        {
            Console.WriteLine(string.Format("{0} {1} {2}mph: {3}", Make, Model, Speed, Message));
        }
    }
}
