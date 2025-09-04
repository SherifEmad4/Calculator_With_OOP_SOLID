public class Calculator
{
    public string Display()
    {
        Console.Clear();
        Console.WriteLine("Enter Your Choice Of Operation Please \n" +
                "1: Addition\n" +
                "2: Subtraction\n" +
                "3: Multiplication\n" +
                "4: Division\n" +
                "5: Power\n" +
                "6: Modulo\n" +
                "7: Square Root\n" +
                "Enter Your Choice Between 1 - 7: ");
        string input = Console.ReadLine();
        return input;
    }
    public bool IsContinue()
    {
        Console.Write("\nDo you want to continue? (yes/no): ");
        var choice = Console.ReadLine().ToLower();
        return choice == "yes";
    }
    public void Start()
    {
        bool ContinueChoice = true ;

        while (ContinueChoice)
        {
            string input = Display();

            if (!IsValidatedOperation(input))
            {
                Console.WriteLine("You Have Entered Wrong Input , Please Try Again\n");
                ContinueChoice = IsContinue();
                continue;
            }

            int inputOperation = int.Parse(input);
            var operation = GetOperation(inputOperation);

            if (operation is IOperationWithTwoParameter opTwo)
            {
                Console.Write("Enter First Number: ");
                string inputx = Console.ReadLine();
                Console.Write("Enter Second Number: ");
                string inputy = Console.ReadLine();

                if (!double.TryParse(inputx, out double x))
                {
                    Console.WriteLine("Error in entering First Number, Try Again\n");
                    ContinueChoice = IsContinue();
                    continue;
                }
                if (!double.TryParse(inputy, out double y))
                {
                    Console.WriteLine("Error in entering Second Number, Try Again\n");
                    ContinueChoice = IsContinue();
                    continue;
                }

                if (operation is IValidatableTwoParameters validator &&
                    !validator.Validate(x, y, out string errorMessage))
                {
                    Console.WriteLine(errorMessage);
                    ContinueChoice = IsContinue();

                    continue;
                }
                Console.WriteLine($"The Result Of Your Operation is : {opTwo.Calc(x, y)}");
            }

            else if (operation is IOperationWithOneParameter opOne)
            {
                Console.Write("Enter a Number: ");
                string inputx = Console.ReadLine();

                if (!double.TryParse(inputx, out double x))
                {
                    Console.WriteLine("Error in entering Number, Try Again");
                    ContinueChoice = IsContinue();
                    continue;
                }

                if (operation is IValidatableOneParameter validator &&
                    !validator.Validate(x, out string errorMessage))
                {
                    Console.WriteLine(errorMessage);
                    ContinueChoice = IsContinue();
                    continue;
                }

                Console.WriteLine($"The Result Of Your Operation is : {opOne.Calc(x)}\n");
            }

            ContinueChoice = IsContinue();
        }

    }
    public bool IsValidatedOperation (string operation)=> int.TryParse(operation, out int result) 
        && result >=1 &&result <=7;
    private object GetOperation(int inputOperation)
    {
        switch(inputOperation){
            case 1:
                return new Addition();
            case 2:
                return new Subtraction();
            case 3:
                return new Multiplication();
            case 4:
                return new Division();
            case 5:
                return new Power();
            case 6:
                return new Modulo();
            case 7:
                return new SquareRoot();
            default:
                return new Addition();
        }
    }
    
}

