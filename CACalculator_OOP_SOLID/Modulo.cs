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

