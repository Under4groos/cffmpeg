using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cffmpeg
{
    class Registry
    {
        List<Reg> RegArray = new List<Reg>();

        //string Convert = @"HKEY_CLASSES_ROOT\*\shell\Convert";
        //string command = @"HKEY_CLASSES_ROOT\*\shell\Convert\shell\video to mp3\command";


        public void Add(Reg r) => RegArray.Add(r);

        public Reg Get(string name)
        {
            Reg retReg = new Reg();
            foreach (Reg r in RegArray)
            {
                if (r.GetKey() == name)
                {
                    retReg = r;
                    break;
                }


            }
            return retReg;
        }

    }
}
