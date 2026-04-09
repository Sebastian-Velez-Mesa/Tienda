using System;
using System.Globalization;
using System.Text;

namespace CNegocios
{
    public static class CNUtilidades
    {
        /// <summary>
        /// Elimina las tildes y diacriticos de una cadena de texto.
        /// </summary>
        /// <param name="texto">El texto original.</param>
        /// <returns>El texto sin tildes.</returns>
        public static string RemoverTildes(string texto)
        {
            // Validacion de entrada para evitar procesar cadenas nulas o vacias
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            // Normalizacion FormD: Descompone caracteres (ej: 'á' se convierte en 'a' + '´')
            string normalizedString = texto.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                // Solo mantenemos los caracteres que no sean diacriticos (marcas que no espacian)
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Retorno a FormC: Recompone los caracteres resultantes en una cadena estandar
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
