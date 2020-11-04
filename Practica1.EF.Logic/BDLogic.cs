using Practica1.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.EF.Logic
{
    public abstract class BDLogic
    {

        protected readonly NorthwindContext context;

        public BDLogic()
        {
            this.context = new NorthwindContext();
        }

    }
}
