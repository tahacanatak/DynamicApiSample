using System;
using Abp.Domain.Entities;

namespace DynamicApiSample.Core.Models
{
    public class Person : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}