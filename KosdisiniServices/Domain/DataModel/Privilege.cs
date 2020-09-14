using System;
using System.Collections.Generic;

namespace KosdisiniServices.Domain.DataModel
{
    public class Privilege
    {
        public Privilege()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
