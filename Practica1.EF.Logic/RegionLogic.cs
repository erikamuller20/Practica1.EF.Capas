using Practica1.EF.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.EF.Logic
{
    public class RegionLogic : BDLogic, IABMLogic<Region>
    {
        public void Delete(Region entity)
        {
            throw new NotImplementedException();
        }

        public List<Region> GetAll()
        {
            try
            {
                return context.Region.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }

        public Region GetOne(int id, string ids)
        {
                return context.Region.FirstOrDefault(e => e.RegionID.Equals(id));
        }

        public Region Insert(Region entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Region entity)
        {
            throw new NotImplementedException();
        }
    }
}
