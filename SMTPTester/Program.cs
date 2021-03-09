using System;
using System.Net.Mail;

namespace SMTPTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is the code to send an email message from a console application in C#
            MailMessage Email = new MailMessage();

            var sender = args.Length < 9 ? "" : args[0];
            Console.WriteLine("Sender:" + sender);
            if (string.IsNullOrWhiteSpace(sender)) sender = Console.ReadLine();
            MailAddress Sender = new MailAddress(sender);
            Email.From = Sender; // Set the sender of the email message

            var To = args.Length < 9 ? "" : args[1];
            Console.WriteLine("To:" + To);
            if (string.IsNullOrWhiteSpace(To)) To = Console.ReadLine();
            Email.To.Add(To); // Email address which receives the email

            var Subject = args.Length < 9 ? "" : args[2];
            Console.WriteLine("Subject:" + Subject);
            if (string.IsNullOrWhiteSpace(Subject)) Subject = Console.ReadLine();
            Email.Subject = Subject; // Add emailmessage subject

            var Text = args.Length < 9 ? "" : args[3];
            Console.WriteLine("Text:" + Text);
            if (string.IsNullOrWhiteSpace(Text)) Text = Console.ReadLine();
            Email.Body = Text; // email message text

            var ServerName = args.Length < 9 ? "" : args[4];
            Console.WriteLine("SMTP server:" + ServerName);
            if (string.IsNullOrWhiteSpace(ServerName)) ServerName = Console.ReadLine();
            var Port = args.Length < 9 ? "" : args[5];
            Console.WriteLine("Port:" + Port);
            if (string.IsNullOrWhiteSpace(Port)) Port = Console.ReadLine();
            SmtpClient MailClient = new SmtpClient(ServerName, int.Parse(Port)); //Create object for SMTP server connection, but no login yet

            var UserName = args.Length < 9 ? "" : args[6];
            Console.WriteLine("Username:" + UserName);
            if (string.IsNullOrWhiteSpace(UserName)) UserName = Console.ReadLine();
            var Password = args.Length < 9 ? "" : args[7];
            Console.WriteLine("Password:" + Password);
            if (string.IsNullOrWhiteSpace(Password)) Password = Console.ReadLine();
            System.Net.NetworkCredential Credentials = new System.Net.NetworkCredential(UserName, Password);//Create credentials object for login at smtp server

            MailClient.Credentials = Credentials; //Add credentials to object for smtp server creation

            var SSL = args.Length < 9 ? "" : args[8];
            Console.WriteLine("SSL [Y/N]:" + SSL);
            if (string.IsNullOrWhiteSpace(SSL)) SSL = Console.ReadLine();
            MailClient.EnableSsl = SSL == "Y" ? true : false;

            MailClient.Send(Email); // Send email message. If login at the SMTP server was not possible an exception will be raised at this point.
        }
    }
}
