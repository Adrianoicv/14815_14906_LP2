using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;

namespace DL
{
    public abstract class File
    {

        protected abstract void WriteFile();
        protected abstract void LoadFile();

    }

}