using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Services
{

    public class ContactRepository
    {
        private const string ChaceKey = "ContactStore";

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if(ctx.Cache[ChaceKey] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact
                        {
                            Id = 1,
                            Name = "David Task2"
                        },

                        new Contact
                        {
                            Id = 2,
                            Name = "Mark Task2"
                        }
                    };

                    ctx.Cache[ChaceKey] = contacts;
                }
            }
        }


        public Contact[] GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Contact[])ctx.Cache[ChaceKey];
            }


            return new Contact[]
            {
                new Contact
                {
                    Id = 0,
                    Name = "Placeholder"
                }
           
            };
        }



            public bool SaveContact(Contact contact)
            {
                var ctx = HttpContext.Current;

                if(ctx != null)
                {
                   try{
                       var currentData = ((Contact[])ctx.Cache[ChaceKey]).ToList();
                       currentData.Add(contact);
                       ctx.Cache[ChaceKey] = currentData.ToArray();

                       return true;
                   }
                    catch(Exception ex)
                   {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }
                }
                return false;
            }


        
    }
}