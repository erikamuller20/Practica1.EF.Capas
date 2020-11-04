using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.EF.Logic
{
    interface IABMLogic<T>
    {
        //Devuelve todos los registros de una tabla T
        List<T> GetAll();

        //Devuelve solo 1 registro de una tabla T
        T GetOne(int id, string ids);

        T Insert(T entity);
        
        void Update(T entity);

        void Delete(T entity);

    }
}
