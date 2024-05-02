using iscaPopAlvaro.BaseDades;
using iscaPopAlvaro.Model;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.Dao
{
    public class MaterialDAO
    {
        public MaterialDAO() { }

        public void insertarMaterial(Material material)
        {
            BaseDatos.GetConnection().InsertWithChildrenAsync(material);
        }


    }
}
