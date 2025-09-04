

using System;

Calculator calculator = new Calculator();
calculator.Start();




public interface IOperationWithTwoParameter
{
    double Calc(double x, double y);
    //bool Validate(double x, double y, out string errorMessage);
}

public interface IOperationWithOneParameter
{
    double Calc(double x);
    //bool Validate(double x,out string errorMessage);
}
public interface IValidatableTwoParameters
{
    bool Validate(double x, double y, out string errorMessage);
}

public interface IValidatableOneParameter
{
    bool Validate(double x, out string errorMessage);
}

public class Addition : IOperationWithTwoParameter
{
    public double Calc(double x , double y) => x + y;
}

public class Subtraction : IOperationWithTwoParameter , IValidatableTwoParameters
{
    public double Calc(double x , double y) => x - y;
    public bool Validate(double x, double y, out string errorMessage)
    {
        errorMessage = "";
        return true;
    }
}
public class Multiplication : IOperationWithTwoParameter
{
    public double Calc(double x , double y ) => x * y;
}
public class Division : IOperationWithTwoParameter , IValidatableTwoParameters
{
    public double Calc(double x, double y) => (double)x / (double)y;
    public bool Validate(double x, double y, out string errorMessage)
    {
        if (y == 0)
        {

            errorMessage = "You Have Divided By Zero";
            return false;
        }
        errorMessage = "";
        return true;
    }
}
public class Power:IOperationWithTwoParameter 
{
    public double Calc(double x , double y)=> Math.Pow(x, y);

}
public class Modulo : IOperationWithTwoParameter , IValidatableTwoParameters
{
    public double Calc(double x, double y) => x % y;
    public bool Validate(double x, double y, out string errorMessage)
    {
        if (y == 0)
         {
             errorMessage = "Error , You Have Module By Zero";
             return false;
         }
        errorMessage = "";
        return true;
    }

}
public class SquareRoot : IOperationWithOneParameter , IValidatableOneParameter
{
    public double Calc(double x) => Math.Sqrt(x);
    public bool Validate(double y, out string errorMessage)
     {
        if (y < 0)
        {
           errorMessage = "Error , You Have Square Root Number Less Than 0 ";
           return false;
        }
        errorMessage = "";
        return true;
    }
}

public class Calculator
{
    public void Start()
    {
        bool ContinueChoice = true ;
        string choice;
        while (ContinueChoice)
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
            if (!IsValidatedOperation(input))
            {
                Console.WriteLine("You Have Entered Wrong Input , Please Try Again\n");
                Console.Write("\nDo you want to continue? (yes/no): ");
                choice = Console.ReadLine().ToLower();
                if (choice != "yes")
                    ContinueChoice = false;
                continue;
            }

            int inputOperation = int.Parse(input);
            var operation = GetOperation(inputOperation);

            // Handle operations with two parameters
            if (operation is IOperationWithTwoParameter opTwo)
            {
                Console.Write("Enter First Number: ");
                string inputx = Console.ReadLine();
                Console.Write("Enter Second Number: ");
                string inputy = Console.ReadLine();

                if (!double.TryParse(inputx, out double x))
                {
                    Console.WriteLine("Error in entering First Number, Try Again\n");
                    Console.Write("\nDo you want to continue? (yes/no): ");
                     choice = Console.ReadLine().ToLower();
                    if (choice != "yes")
                        ContinueChoice = false;
                    continue;
                }
                if (!double.TryParse(inputy, out double y))
                {
                    Console.WriteLine("Error in entering Second Number, Try Again\n");
                    Console.Write("\nDo you want to continue? (yes/no): ");
                    choice = Console.ReadLine().ToLower();
                    if (choice != "yes")
                        ContinueChoice = false;
                    continue;
                }

                // Validation
                if (operation is IValidatableTwoParameters validator &&
                    !validator.Validate(x, y, out string errorMessage))
                {
                    Console.WriteLine(errorMessage);
                    Console.Write("\nDo you want to continue? (yes/no): ");
                    choice = Console.ReadLine().ToLower();
                    if (choice != "yes")
                        ContinueChoice = false;

                    continue;
                }
                Console.WriteLine($"The Result Of Your Operation is : {opTwo.Calc(x, y)}");
            }
            // Handle operations with one parameter (e.g., Square Root)
            else if (operation is IOperationWithOneParameter opOne)
            {
                Console.Write("Enter a Number: ");
                string inputx = Console.ReadLine();

                if (!double.TryParse(inputx, out double x))
                {
                    Console.WriteLine("Error in entering Number, Try Again");
                    Console.Write("\nDo you want to continue? (yes/no): ");
                    choice = Console.ReadLine().ToLower();
                    if (choice != "yes")
                        ContinueChoice = false;
                    continue;
                }

                // Validation
                if (operation is IValidatableOneParameter validator &&
                    !validator.Validate(x, out string errorMessage))
                {
                    Console.WriteLine(errorMessage);
                    Console.Write("\nDo you want to continue? (yes/no): ");
                    choice = Console.ReadLine().ToLower();
                    if (choice != "yes")
                        ContinueChoice = false;
                    continue;
                }

                Console.WriteLine($"The Result Of Your Operation is : {opOne.Calc(x)}\n");
            }

            Console.Write("\nDo you want to continue? (yes/no): ");
            choice = Console.ReadLine().ToLower();
            if (choice != "yes")
                ContinueChoice = false;
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

