using System.ComponentModel.DataAnnotations;

namespace ColNet2._0.CustomModels
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            string email = value as string;
            if (email.Contains("@"))
            {
                string[] strings = value.ToString().Split('@');
            
                if (strings[1].ToLower() == AllowedDomain.ToLower())
                {
                    return null;
                }
            }
            return new ValidationResult($"Le domaine doit etre {AllowedDomain}",
            new[] { validationContext.MemberName });
        }
    }
}
