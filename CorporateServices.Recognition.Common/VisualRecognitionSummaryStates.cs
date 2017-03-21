using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateServices.Recognition.Common
{
    /// <summary>
	/// Итоговый статус распознавания
	/// </summary>
	public enum VisualRecognitionSummaryStates : short
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Ошибка
        /// </summary>
        Error = 1,

        /// <summary>
        /// Распознавание прошло без ошибок 
        /// </summary>
        Ok = 2,

        /// <summary>
        /// Требуется повторное распознавание
        /// </summary>
        ShouldBeRecognizedAgain = 3
    }
}
