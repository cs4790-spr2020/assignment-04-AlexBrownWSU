using System;
using System.Net.Mail;
using BlabberApp.Domain.Interfaces;
namespace BlabberApp.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id {get; set;}
        public System.DateTime RegisterDTTM { get; set; }
        public System.DateTime LastLoginDTTM { get; set; }
        public string Email { get; private set; }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length > 50)
                throw new FormatException("Email is invalid");
            try
            {
                MailAddress m = new MailAddress(email); 
            }
            catch (FormatException)
            {
                throw new FormatException("Email is invalid");
            }
            Email = email;
        }
        public bool IsValid()
        {
            if (this.Id == null) throw new ArgumentNullException();
            if (this.Email == null) throw new ArgumentNullException();
            if (this.Email.ToString() == "") throw new FormatException();
            if (this.LastLoginDTTM == null) throw new ArgumentNullException();
            if (this.RegisterDTTM == null) throw new ArgumentNullException();
            return true;
        }
    }
}