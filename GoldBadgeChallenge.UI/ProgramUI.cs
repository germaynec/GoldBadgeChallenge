using static System.Console;

public class ProgramUI
{
    private DeliveryRepository _dRepo = new DeliveryRepository();

    public void Run()
    {
        SeedDeliveries();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Clear();
           Console.ForegroundColor = ConsoleColor.Blue; // Set text color to blue
            WriteLine("===============================================");
            WriteLine("|            WELCOME MENU                     |");
            WriteLine("===============================================");
            Console.ResetColor();
            WriteLine("1. Retrieve All Deliveries");
            WriteLine("2. View All Enroute Deliveries");
            WriteLine("3. View All Completed Deliveries");
            WriteLine("4. Retrieve a Delivery by Customer ID");
            WriteLine("5. Add Delivery");
            WriteLine("6. Update Delivery Status");
            WriteLine("7. Delete Delivery Entry");
            WriteLine("0. Exit Program");

            var userInput = int.Parse(ReadLine()!);
            switch (userInput)
            {
                case 1:
                    GetAllDeliveries();
                    break;
                case 2:
                    GetAllEnrouteDeliveries();
                    break;
                case 3:
                    GetAllCompletedDeliveries();
                    break;
                case 4:
                    GetDeliveryByCustomerId();
                    break;
                case 5:
                    AddDelivery();
                    break;
                case 6:
                    UpdateDeliveryStatus();
                    break;
                case 7:
                    DeleteDelivery();
                    break;
                case 00:
                    isRunning = Quit();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; 
                    WriteLine("Invalid Option/Option not defined");
                    Console.ResetColor(); 
                    break;
            }
        }
    }

    private void SeedDeliveries()
    {
        Clear();

        DateTime od1 = new DateTime(2023, 8, 24);
        DateTime dd1 = new DateTime(2023, 8, 28);
        Status ds1 = new Status();
        ds1 = Status.Complete;
        Delivery delivery1 = new Delivery(od1, dd1, 20, 2);
        _dRepo.AddDelivery(delivery1);
        _dRepo.UpdateStatusType(delivery1.customerID, ds1);

        DateTime od2 = new DateTime(2023, 9, 7);
        DateTime dd2 = new DateTime(2023, 10, 01);
        Status ds2 = new Status();
        ds2 = Status.Scheduled;
        Delivery delivery2 = new Delivery(od2, dd2, 43, 7);
        _dRepo.AddDelivery(delivery2);
        _dRepo.UpdateStatusType(delivery2.customerID, ds2);

        DateTime od3 = new DateTime(2023, 9, 20);
        DateTime dd3 = new DateTime(2023, 9, 11);
        Status ds3 = new Status();
        ds3 = Status.EnRoute;
        Delivery delivery3 = new Delivery(od3, dd3, 69, 4);
        _dRepo.AddDelivery(delivery3);
        _dRepo.UpdateStatusType(delivery3.customerID, ds3);
    }

    private void DeleteDelivery()
    {
        Clear();
        WriteLine("===Delete Delivery Menu===");
        WriteLine("Please enter the ID of the Delivery Entry to be Deleted");
        var userInput = int.Parse(ReadLine()!);
        bool isDeleted = _dRepo.DeleteDelivery(userInput);
        if (isDeleted)
        {
            WriteLine("Successfully Deleted Delivery Entry");
        }
        else
        {
            WriteLine("Failed to Delete Delivery Entry");
        }
        PressAnyKeyToContinue();
    }

    private void UpdateDeliveryStatus()
    {
        Clear();
        Delivery delivery = new Delivery();
        Status status;
        WriteLine("===Status Update Menu===");
        WriteLine("Please enter the ID of the delivery that needs updated");
        var userInputDelId = int.Parse(ReadLine()!);
        if(_dRepo.GetDeliveryByCustomerId(userInputDelId) != null)
        {
            delivery = _dRepo.GetDeliveryByCustomerId(userInputDelId);
        WriteLine("Please enter the Status ID you wish to change to\n" +
                "1. Scheduled\n" +
                "2. EnRoute\n" +
                "3. Complete\n" +
                "4. Cancelled");
        var userInputStatusId = int.Parse(ReadLine()!);
        switch (userInputStatusId)
        {
            case 1:
                status = Status.Scheduled;
                _dRepo.UpdateStatusType(delivery.customerID, status);
                break;
            case 2:
                status = Status.EnRoute;
                _dRepo.UpdateStatusType(delivery.customerID, status);
                break;
            case 3:
                status = Status.Complete;
                _dRepo.UpdateStatusType(delivery.customerID, status);
                break;
            case 4:
                status = Status.Cancelled;
                _dRepo.UpdateStatusType(delivery.customerID, status);
                break;
            default:
                WriteLine("Invalid Selection...");
                break;
        }
        PressAnyKeyToContinue();
        }
        else
        {
            WriteLine("That is not a customerID");
            PressAnyKeyToContinue();
        }
    }

    private void AddDelivery()
    {
        Clear();
        WriteLine("===Add Delivery Menu===");
        DateTime orderDate = DateTime.Now;
        DateTime deliveryDate = PromptDeliveryDate();
        WriteLine("What is the item number? ");
        var userInput = int.Parse(ReadLine()!);
        WriteLine("How many items are they getting? ");
        var userInput2 = int.Parse(ReadLine()!);
        Delivery newDelivery = new Delivery(orderDate, deliveryDate, userInput, userInput2);
        newDelivery.DeliveryStatus = Status.Scheduled;

        _dRepo.AddDelivery(newDelivery);
        PressAnyKeyToContinue();
    }

    private void GetDeliveryByCustomerId()
    {
        Clear();
        WriteLine("===Get Delivery By ID Menu===");
        Delivery delivery = new Delivery();
        WriteLine("Please enter the ID of the customer you wish to view.");
        var userInput = int.Parse(ReadLine()!);
        delivery = _dRepo.GetDeliveryByCustomerId(userInput);
        WriteLine(delivery);
        PressAnyKeyToContinue();
    }

    private void GetAllCompletedDeliveries()
    {
        Clear();
        WriteLine("===All Completed Deliveries Menu===");
        List<Delivery> completedDeliveries = new List<Delivery>();
        completedDeliveries = _dRepo.GetCompletedDeliveries();
        foreach (var delivery in completedDeliveries)
        {
            WriteLine(delivery);
        }
        PressAnyKeyToContinue();
    }

    private void GetAllEnrouteDeliveries()
    {
        Clear();
        WriteLine("====All EnRoute Deliveries Menu===");
        List<Delivery> enrouteDeliveries = new List<Delivery>();
        enrouteDeliveries = _dRepo.GetEnRouteDeliveries();
        foreach (var delivery in enrouteDeliveries)
        {
            WriteLine(delivery);
        }
        PressAnyKeyToContinue();
    }

    private void GetAllDeliveries()
    {
        Clear();
        WriteLine("===All Deliveries===");

        List<Delivery> deliveries = new List<Delivery>();
        deliveries = _dRepo.GetDeliveries();
        foreach (var delivery in deliveries)
        {
            WriteLine(delivery);
        }
        PressAnyKeyToContinue();
    }

    private bool Quit()
    {
        Clear();
        WriteLine("Please Press any key to end this application");
        ReadKey();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        WriteLine("Press any key to continue");
        ReadKey();
    }

    private DateTime PromptDeliveryDate()
    {
        WriteLine("You will be asked to enter the Delivery date in format | Month | Day | Year |");
        WriteLine("Please enter Month: ");
        var month = int.Parse(ReadLine()!);

        WriteLine("Please enter Day: ");
        var day = int.Parse(ReadLine()!);

        WriteLine("Please enter Year: ");
        var year = int.Parse(ReadLine()!);

        DateTime newDateTime = new DateTime(year, month, day);

        return newDateTime;
    }
}