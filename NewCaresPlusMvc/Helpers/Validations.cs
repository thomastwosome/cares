using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace NewCaresPlusMvc.Helpers
{
    public class BooleanMustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object propertyValue)
        {
            return propertyValue != null
                && propertyValue is bool
                && (bool)propertyValue;
        }
    }

    public class EnsureMinimumElementsAttribute : ValidationAttribute
    {
        private readonly int _minElements;

        public EnsureMinimumElementsAttribute(int minElements)
        {
            _minElements = minElements;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;

            if (list != null)
            {
                return list.Count >= _minElements;
            }

            return false;
        }
    }

    public class RequiredIfAttribute : RequiredAttribute
    {
        private string PropertyName { get; set; }
        private object DesiredValue { get; set; }

        public RequiredIfAttribute(string propertyName, object desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var instance = context.ObjectInstance;
            var type = instance.GetType();
            var proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue.ToString() == DesiredValue.ToString())
            {
                var result = base.IsValid(value, context);
                return result;
            }
            return ValidationResult.Success;
        }
    }
}