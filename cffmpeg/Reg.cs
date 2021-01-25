using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cffmpeg
{
    class Reg
    {
        private string Name
        {
            get;set;
        }
        private string Key
        {
            get; set;
        }

        public Reg(string n , string k)
        {
            Name = n;
            Key = k;
        }
        public Reg()
        {}
        public string GetName()
        {
            return Name;
        }
        public string GetKey()
        {
            return Key;
        }

    }

}
