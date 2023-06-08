﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediKit.BC
{
    public class CommonBC
    {
        /// <summary>
        ///  Sincroniza los valores de propiedades comunes entre 2 objetos
        /// </summary>/// 
        ///<param name="origen">Objeto con los valores a copiar hacia el destino.</param>
        /// <param name="destino">Objeto que recibe la copia de los valores en sus propiedades</param>
        internal static void Syncronize(object origen, object destino)
        {
            /* Auxiliares para Reflection del Tipo de Dato Origen */
            Type tipo = null;PropertyInfo[] propiedades = null;
            /* Obtiene información del Tipo Origen y sus Propiedades */
            tipo = origen.GetType();propiedades = tipo.GetProperties();
            /* Recorre las propiedades del Origen para asignar los valores al destino */
            foreach (PropertyInfo propiedad in propiedades)
            {
                try
                {
                    /* Recupera propiedad destino por su nombre */
                    PropertyInfo propInfo = destino.GetType().GetProperty(propiedad.Name);
                    /* Asigna valor destino desde el origen */
                    propInfo.SetValue(destino, propiedad.GetValue(origen, null));
                }catch (Exception ex)
                {
                    /* Los valores que no se pueden asignar son ignorados */
                    System.Diagnostics.Debug.WriteLine($"No se pudo asignar la propiedad {propiedad.Name}: {ex}");
                }
            }
        }
    }
}
