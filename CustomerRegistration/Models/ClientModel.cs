using System;

namespace CustomerRegistration.Models
{
    class ClientModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string Nationality { get; set; }
        public string Schooling { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public ClientModel(string name, string cpf, DateTime birth, string gender, string bloodType,
            string nationality, string schooling, string phone, string email, string cep, string street,
            string number, string district, string city, string state)
        {
            Name = name;
            Cpf = cpf;
            Birth = birth;
            Gender = gender;
            BloodType = bloodType;
            Nationality = nationality;
            Schooling = schooling;
            Phone = phone;
            Email = email;
            CEP = cep;
            Street = street;
            Number = number;
            District = district;
            City = city;
            State = state;
        }
    }
}
