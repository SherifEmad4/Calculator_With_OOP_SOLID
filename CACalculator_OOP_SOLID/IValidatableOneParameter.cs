public interface IValidatableOneParameter
{
    bool Validate(double x, out string errorMessage);
}

