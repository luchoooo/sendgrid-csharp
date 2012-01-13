﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using SendGridMail;
using SendGridMail.Transport;

namespace Example
{
    class SMTPAPI
    {
        private String _username;
        private String _password;
        private String _from;
        private IEnumerable<string> _to;

        public SMTPAPI(String username, String password, String from, IEnumerable<string> recipients)
        {
            _username = username;
            _password = password;
            _from = from;
            _to = recipients;
        }

        public void SimpleHTMLEmail()
        {
            //create a new message object
            var message = SendGrid.GenerateInstance();

            //set the message recipients
            foreach(string recipient in _to)
            {
                message.AddTo(recipient);
            }

            //set the sender
            message.From = new MailAddress(_from);

            //set the message body
            message.Html = "<html><p>Hello</p><p>World</p></html>";

            //set the message subject
            message.Subject = "Hello World Simple Test";

            //create an instance of the SMTP transport mechanism
            var smtpInstance = SMTP.GenerateInstance(new NetworkCredential(_username, _password));

            //send the mail
            smtpInstance.Deliver(message);
        }

        public void SimplePlaintextEmail()
        {
            //create a new message object
            var message = SendGrid.GenerateInstance();

            //set the message recipients
            foreach(string recipient in _to)
            {
                message.AddTo(recipient);
            }

            //set the sender
            message.From = new MailAddress(_from);

            //set the message body
            message.Text = "Hello World Plain Text";

            //set the message subject
            message.Subject = "Hello World Simple Test";

            //create an instance of the SMTP transport mechanism
            var smtpInstance = SMTP.GenerateInstance(new NetworkCredential(_username, _password));

            //send the mail
            smtpInstance.Deliver(message);
        }

        public void EnableGravatarEmail()
        {
            var header = new Header();
            //create a new message object
            var message = SendGrid.GenerateInstance();

            //set the message recipients
            foreach (string recipient in _to)
            {
                message.AddTo(recipient);
            }

            //set the sender
            message.From = new MailAddress(_from);

            //set the message body
            message.Html = "<p style='color:red';>Hello World Gravatar Email</p>";

            //set the message subject
            message.Subject = "Hello World Simple Test";

            //create an instance of the SMTP transport mechanism
            var smtpInstance = SMTP.GenerateInstance(new NetworkCredential(_username, _password));
            
            //enable gravatar
            message.EnableGravatar();

            Console.WriteLine(header.AsJson());

            Console.WriteLine("done");
            //send the mail
            smtpInstance.Deliver(message);
        }

        public void EnableOpenTrackingEmail()
        {
            var header = new Header();
            //create a new message object
            var message = SendGrid.GenerateInstance();

            //set the message recipients
            foreach (string recipient in _to)
            {
                message.AddTo(recipient);
            }

            //set the sender
            message.From = new MailAddress(_from);

            //set the message body
            message.Html = "<p style='color:red';>Hello World Plain Text</p>";

            //set the message subject
            message.Subject = "Hello World Simple Test";

            //create an instance of the SMTP transport mechanism
            //var smtpInstance = SMTP.GenerateInstance(new NetworkCredential(_username, _password));

            //enable gravatar
            message.EnableOpenTracking();

            Console.WriteLine(header.AsJson());

            Console.WriteLine("done");
            //send the mail
            //smtpInstance.Deliver(message);
        }

    }
}