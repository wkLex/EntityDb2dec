// See https://aka.ms/new-console-template for more information
using EntityDb2dec;

//Interactive Console App in Entity Framework
//For Crud - create, read, update, delete
//Car database where user can add, see, update and delete objects

MyDbContext Context = new MyDbContext();

//Car Car1 = new Car();

bool Run = true;

while (Run)
{
    Console.WriteLine("Choose a number: ");
    Console.WriteLine();
    Console.WriteLine("1. List all cars");
    Console.WriteLine("2. Add a new car");
    Console.WriteLine("3. Edit a car");
    Console.WriteLine("4. Delete a car");
    Console.WriteLine("5. Exit application");

    Console.WriteLine();
    Console.Write("Make your choice:  ");
    Console.WriteLine();
    string UserChoice = Console.ReadLine();
    Console.WriteLine();

    if (UserChoice == "1")
    {
        List<Car> Cars = Context.Cars.ToList();

        Console.WriteLine("Here's all the cars in the database: ");
        Console.WriteLine();
        foreach (Car Car in Cars)
        {
            Console.WriteLine($"{Car.Brand} {Car.Model} {Car.Year}");

        }

        Console.WriteLine();

    }

    else if (UserChoice == "2")
    {

        Car Car1 = new Car();

        //Console.WriteLine("We are going to store car data in the database.");
        Console.WriteLine("Please, enter the details of the car.");
        Console.WriteLine();

        Console.Write("Brand:  ");
        string Brand = Console.ReadLine();

        Console.Write("Model:  ");
        string Model = Console.ReadLine();

        Console.Write("Year:   ");
        string Year = Console.ReadLine();

        Car1.Brand = Brand;
        Car1.Model = Model;
        Car1.Year = Year;

        Context.Cars.Add(Car1);
        Context.SaveChanges();
        Console.WriteLine();
        Console.WriteLine("The information was saved.");
        Console.WriteLine();
    }


    else if (UserChoice == "3")
    {
        Console.WriteLine("Choose a car to edit");
        Console.WriteLine();
        List<Car> Cars = Context.Cars.ToList();

        foreach (Car Car in Cars)

        {
            Console.WriteLine($"{Car.Id} {Car.Brand} {Car.Model} {Car.Year}");
            Console.WriteLine();

        }

        Console.Write("Choose a car number to edit: ");
        string EditCar = Console.ReadLine();
        Car CarToEdit = Context.Cars.FirstOrDefault(x => x.Id == Convert.ToInt32(EditCar));

        Console.WriteLine("Enter new data:");

        Console.Write("Brand:  ");
        string Brand = Console.ReadLine();

        Console.Write("Model:  ");
        string Model = Console.ReadLine();

        Console.Write("Year:   ");
        string Year = Console.ReadLine();

        CarToEdit.Brand = Brand;
        CarToEdit.Model = Model;
        CarToEdit.Year = Year;

        Context.Cars.Update(CarToEdit);
        Context.SaveChanges();
        Console.WriteLine("The new information was saved.");
        Console.WriteLine();
    }

    else if (UserChoice == "4")
    {
        Console.WriteLine("Choose a car to delete.");
        List<Car> Cars = Context.Cars.ToList();

        {
            foreach (Car Car in Cars)
                Console.WriteLine($"{Car.Id} {Car.Brand} {Car.Model} {Car.Year}");
            Console.WriteLine();
        }

        Console.Write("Choose a car number to delete: ");
        string DeleteCar = Console.ReadLine();
        Car CarToDelete = Context.Cars.FirstOrDefault(x => x.Id == Convert.ToInt32(DeleteCar));

        Context.Cars.Remove(CarToDelete);
        Context.SaveChanges();

        Console.WriteLine();
        Console.WriteLine("The car was deleted.");
        Console.WriteLine();
    }

    else if (UserChoice == "5")
    {
        Run = false;
        Console.WriteLine("Bye for now. See you next time.");
    }
    else
        Console.WriteLine("You have to choose a number between 1 and 5. Try again.");
}


//Context.Cars.Add(Car1);
//Context.SaveChanges();

//Console.WriteLine(Car1.Id);
//Console.WriteLine("We are done.");