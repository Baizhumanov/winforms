using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flex00
{
    class Client
    {
        public string Surname       { get; set; }
        public string Name          { get; set; }
        public string Patronymic    { get; set; } = "";
        public string Phone         { get; set; } = "";
        public string Additional    { get; set; } = "";
        public string DateAdd       { get; set; }
        public string DateUpdate    { get; set; }
    }
}
