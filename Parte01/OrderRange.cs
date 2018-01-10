using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Parte01
{
    public class OrderRange
    {
        /// <summary>
        /// Poblema 02 - retornar una colección de números pares
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns> cadena</returns>

        public string build(int[] parameter)
        {
            string sep = ",";
            if (parameter.Length==0 )
                throw new Exception("El parametro no debe ser un Array vacio.");

            var pares = new List<int>();
            List<int> impares = new List<int>();

            Array.ForEach(parameter,q=> {
                if (q % 2 == 0)
                    pares.Add(q);
                else
                    impares.Add(q);
            });

            var paresOrdenados= pares.OrderBy(p => p).ToArray();
            var imparesOrdenados = impares.OrderBy(p => p).ToArray();

            return string.Format("[{0}] [{1}]", String.Join(sep, imparesOrdenados), String.Join(sep, paresOrdenados));
        }

    }

}
