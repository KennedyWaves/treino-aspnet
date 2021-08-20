using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Data.Converter.Contract
{
    public interface IConverter<I,O>
    {
        /// <summary>
        /// Recebe um objeto de DTO, converte e fornece um model.
        /// </summary>
        /// <param name="input">Objeto DTO</param>
        /// <returns>model</returns>
        O Convert(I input);
        /// <summary>
        /// Recebe uma lista de objetos DTO, converte e fornece uma lista de models.
        /// </summary>
        /// <param name="input">lista de objetos DTO.</param>
        /// <returns>Lista de models.</returns>
        List<O> Convert(List<I> input);
    }
}
