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

