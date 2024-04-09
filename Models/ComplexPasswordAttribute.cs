using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TigerTix.Web.Models
{
public class ComplexPasswordAttribute : ValidationAttribute 
{
public override bool IsValid(object value)
    {
        var password = value as string;

        if (string.IsNullOrEmpty(password))
            return false;

        // At least one uppercase letter
        if (!password.Any(char.IsUpper))
            return false;

        // At least one digit
        if (!password.Any(char.IsDigit))
            return false;

        // At least one special character
        var specialCharacters = new Regex(@"[^A-Za-z0-9]");
        if (!specialCharacters.IsMatch(password))
            return false;

        // Minimum length of 7 characters
        if (password.Length < 7)
            return false;

        return true;
    }
}


}