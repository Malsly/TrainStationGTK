using System;
namespace TrainStation
{
    public class Passanger
    {
        private string name { get; set; }
        private string telephone { get; set; }
        private string email { get; set; }

        public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }

        public string Email   // property
        {
            get { return email; }   // get method
            set { 
                if (value.Contains("@")) 
                {
                    email = value;
                } 
                else 
                {
                    Deb.Print("Email is not valid");
                }
            }  
        }

        public string Telephone   // property
        {
            get { return telephone; }   // get method
            set { telephone = value; }  // set method
        }

        public Passanger(string Name, string Telephone, string Email)
        {
            this.Name = Name;
            this.Telephone = Telephone;
            this.Email = Email;
        }
    }
}
