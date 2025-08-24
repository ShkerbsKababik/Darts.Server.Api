namespace Darts.Server.Domain.Policies;

public static class UserPolices
{
    // Your array of forbidden characters
    static char[] forbiddenChars = {
            ' ', '\t', '\n', '\r',
            ';', '\'', '"', '`', '|', '&', '$', '%', '\\',
            '*', '?',
            '<', '>', '{', '}', '(', ')', '[', ']',
            '~', '!', '@', '#', '^', '+', '=', ':'
        };

    public static bool CanUserBeCreated(string login, string password)
    { 
        if(string.IsNullOrEmpty(login)) return false;
        if(string.IsNullOrEmpty(password)) return false;

        // Check if the login string contains ANY of the forbidden characters
        if (login.Any(c => forbiddenChars.Contains(c)))
        {
            return false;
        }

        return true;
    }
}
