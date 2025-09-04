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

