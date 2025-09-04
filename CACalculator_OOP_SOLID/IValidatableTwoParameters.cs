public interface IValidatableTwoParameters
{
    bool Validate(double x, double y, out string errorMessage);
}

