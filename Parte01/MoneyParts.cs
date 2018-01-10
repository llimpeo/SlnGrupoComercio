using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Parte01
{
    public class MoneyParts
    {

        /// <summary>
        /// Poblema 03 - devuelve la salida del algoritmo
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns> cadena</returns>

        public string build(string parameter)
        {

            decimal[] Denominacion = { (decimal)0.05, (decimal)0.1, (decimal)0.2, (decimal)0.5, 1, 2, 5, 10, 20, 50, 100, 200 };
            decimal Monto;

            if (string.IsNullOrEmpty(parameter) || String.IsNullOrWhiteSpace(parameter))
                throw new Exception("El parametro no debe ser nulo o vacio.");

            if (!Decimal.TryParse(parameter, out Monto))
                throw new Exception("El parametro no reprecenta un valor monetario.");


            var ListCantidades = new List<int>();

            foreach (decimal p in Denominacion)
            {
                int r = Convert.ToInt32(Monto / p);
                ListCantidades.Add(r);
            }

            var CantidadFactores = new List<decimal>();


            int q = 0;
            ListCantidades.ForEach(p =>
            {
                CantidadFactores.AddRange(Valores(p, Denominacion[q]));
                q++;
            });


            var Agupaciones = new List<decimal[]>();

            //generamos la lista que contiene los array que cumplen con la condicion
            // la Suma de los factores del array igual al valor ingresado.

            for (int i = 1; i <= ListCantidades[0]; i++)
                Agupaciones.AddRange(VarConRep(CantidadFactores.ToArray(), i, Monto));


            //Concatenar Array que cumple con la condicion.
            List<string> AgrupacionArray = new List<string>();

            foreach (var p in Agupaciones)
                AgrupacionArray.Add(ArrayConcatenado(p));


            //resultado final
            return ArrayConcatenado(AgrupacionArray.ToArray());
        }


        private List<decimal> Valores(int cantidad, decimal denominacion)
        {
            if (cantidad == 0)
                return new List<decimal>();

            var Lista = new List<decimal>();

            for (int i = 0; i < cantidad; i++)
                Lista.Add(denominacion);

            return Lista;

        }


        private string ArrayConcatenado(decimal[] parameter)
        {
            string sep = ",";
            return string.Format("[{0}]", String.Join(sep, parameter));
        }

        private string ArrayConcatenado(string[] parameter)
        {
            string sep = ",";
            return string.Format("[{0}]", String.Join(sep, parameter));
        }


        #region [Generador de combinatorio]
        public List<decimal[]> VarConRep(decimal[] original, int largo, decimal valorIgualar)
        {
            List<decimal[]> lista = new List<decimal[]>();
            ImplementVarConRep(original, new decimal[largo], lista, 0, valorIgualar);
            return lista;
        }

        private void ImplementVarConRep(decimal[] original, decimal[] temp, List<decimal[]> lista, int pos, decimal valorIgualar)
        {
            if (pos == temp.Length)
            {
                decimal[] copia = new decimal[pos];
                Array.Copy(temp, copia, pos);

                if (copia.Sum() == valorIgualar)
                {
                    var flag = true;
                    foreach (var q in lista)
                    {
                        if (q.SequenceEqual(copia))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        lista.Add(copia);
                }
            }
            else
                for (int i = 0; i < original.Length; i++)
                {
                    temp[pos] = original[i];
                    ImplementVarConRep(original, temp, lista, pos + 1, valorIgualar);
                }
        }

        #endregion

    }


}
