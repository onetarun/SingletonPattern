using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.APP.Models
{
    public class MyApiSettings
    {
        public string BaseAddress { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
