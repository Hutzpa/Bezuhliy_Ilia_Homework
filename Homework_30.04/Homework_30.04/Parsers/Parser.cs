using Homework_30._04.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_30._04.Parsers
{
    public abstract class Parser<T> where T : ContentFile
    {
        /// <summary>
        /// Выбирает строки с определённым типом файла
        /// </summary>
        /// <param name="text">Неподготовленная строка</param>
        /// <returns></returns>
        public abstract List<string[]> PickOut(string text);

        /// <summary>
        /// Парсит подготовленные строки в соответствии с указанным типом
        /// </summary>
        /// <param name="text">Возвращает массив уже готовых строк</param>
        /// <returns></returns>
        public abstract List<T> Parse(List<string[]> text);

    }
}
