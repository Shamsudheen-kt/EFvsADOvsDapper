using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.EntityModel
{
    public class Address
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Address1 { get; set; }
        [MaxLength(200)]
        public string Address2 { get; set; }
        [MaxLength(200)]
        public string Address3 { get; set; }
        [MaxLength(200)]
        public string Address4 { get; set; }
        [MaxLength(200)]
        public string Address5 { get; set; }
    }
}
