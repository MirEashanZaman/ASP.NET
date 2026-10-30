using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Attributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private int minv;
        public MinValueAttribute(int _minv)
        {
            minv = _minv;
            ErrorMessage = "Value cannot be less than " + _minv;
        }
        public override bool IsValid(object? value)
        {
            if (value is int a)
            {
                if (a < minv)
                    return false;
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}