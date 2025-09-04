public class Subtraction : IOperationWithTwoParameter , IValidatableTwoParameters
{
    public double Calc(double x , double y) => x - y;
    public bool Validate(double x, double y, out string errorMessage)
    {
        errorMessage = "";
        return true;
    }
}

