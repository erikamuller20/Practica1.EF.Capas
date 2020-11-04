using Practica1.EF.Data;
using Practica1.EF.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Spatial;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1.EF.Logic
{
    public class EmployeesLogic : BDLogic, IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employees GetOne(int id, string ids)
        {

            return context.Employees.FirstOrDefault(e => e.EmployeeID.Equals(id));
        }

        public Employees Insert(Employees entity)
        {
                Employees NuevoEmpl = context.Employees.Add(entity);

                NuevoEmpl.LastName = entity.LastName;
                NuevoEmpl.FirstName = entity.FirstName;
                NuevoEmpl.BirthDate = entity.BirthDate;
                NuevoEmpl.Region = entity.Region;

                context.SaveChanges();
                return NuevoEmpl;
        }

        public void Delete(Employees entity)
        {
            try
            {
                Employees employeesDelete = GetOne(entity.EmployeeID, "");
                context.Employees.Remove(employeesDelete);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Employees entity)
        {
            Employees EmplModif = GetOne(entity.EmployeeID, "");

            EmplModif.LastName  = entity.LastName;
            EmplModif.FirstName = entity.FirstName;
            EmplModif.BirthDate = entity.BirthDate;
            EmplModif.Region = entity.Region;

            context.Entry(EmplModif).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();            
        }
    }

}
