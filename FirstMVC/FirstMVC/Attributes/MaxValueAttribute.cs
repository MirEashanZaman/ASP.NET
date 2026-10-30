using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Attributes
{
    public class MaxValueAttribute : ValidationAttribute
    {
        private int maxv;
        public MaxValueAttribute(int _maxv)
        {
            maxv = _maxv;
        }
        public override bool IsValid(object? value)
        {
            if (value is int a)
            {
                if (a > maxv)
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
