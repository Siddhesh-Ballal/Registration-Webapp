﻿namespace RegistrationTask.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int PINCode { get; set; }

    }
}
