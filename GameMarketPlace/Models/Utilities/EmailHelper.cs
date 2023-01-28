using System.Diagnostics;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace GameMarketPlace.Models.Utilities;

public class EmailHelper
{
    private const string EMAIL = "gamemarketplace6@gmail.com";
    private const string PASSWORD = "xvwuarocgcjzrnwd";
    
   
    private static MimeMessage FormatEmail(MailboxAddress address, string subject, string body)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("GMP", EMAIL));
        email.To.Add(address);

        email.Subject = subject;
        email.Body = new TextPart("plain")
        {
            Text = body,
        };

        return email;
    } 
    
    public bool SendConfirmationEmail(string userEmail, string confirmationLink)
    {
        const string SUBJECT = "Confirm your email";
        var email = FormatEmail(new MailboxAddress("user", userEmail), SUBJECT, confirmationLink);
        
        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 465, true);

            client.Authenticate(EMAIL, PASSWORD);

            client.Send(email);
            client.Disconnect(true);
            client.Dispose();
            return true;
        }
    }

    public bool SendForgotPasswordEmail(string userEmail, string password)
    {
        const string SUBJECT = "Forgot your password";
        var email = FormatEmail(new MailboxAddress("user", userEmail), SUBJECT, password);

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 465, true);

            client.Authenticate(EMAIL, PASSWORD);

            client.Send(email);
            client.Disconnect(true);
            client.Dispose();
            return true;
        }    
    }

}