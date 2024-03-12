using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notification
{
    public class Notifie
    {
        [NotMapped]
        public string NameOfProperty { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public List<Notifie> Notifications;

        public Notifie() 
        {
            Notifications = new List<Notifie>();
        }

        public Boolean ValidatePropertyString(string value, string nameOfProperty)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(nameOfProperty))
            {
                Notifications.Add(new Notifie
                {
                    Message = "Mandatory Value !",
                    NameOfProperty = nameOfProperty
                });
                return false;
            }
            return true;
        }

        public Boolean ValidatePropertyDecial(decimal value, string nameOfProperty)
        {
            if (value < 1 || string.IsNullOrEmpty (nameOfProperty))
            {
                Notifications.Add(new Notifie
                { 
                    Message = "the number must be greater than zero",
                    NameOfProperty = nameOfProperty
                });

                return false;
            }
            return true;
        }
    }
}
