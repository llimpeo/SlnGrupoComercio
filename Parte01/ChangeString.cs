using System;

namespace Parte01
{
    public class ChangeString
    {
        /// <summary>
        /// Poblema 01 - Reemplazar cada letra de la cadena
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns> cadena</returns>

        public string build(string parameter)
        {

                if (string.IsNullOrEmpty(parameter) || String.IsNullOrWhiteSpace(parameter))
                    throw new Exception("El parametro no debe ser nulo o vacio.");

                char[] Arr = parameter.ToCharArray();

                for (int i=0; i < Arr.Length; i++)
                {
                    var p = Arr[i];
                    if (char.IsLetter(p))
                    {
                        var q = (int)p+1;
                        if (char.IsLetter((char)q))
                            Arr[i] = (char)q;
                        else
                        {
                            if (p == 'Z')
                            Arr[i] = 'A';
                        else if  (p == 'z')
                                Arr[i] = 'a';
                        }                     
                    }
                }
              return  new string(Arr);
        }

    }
}
