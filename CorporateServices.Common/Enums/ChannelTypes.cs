using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateServices.Common.Enums
{
    /// <summary>
	/// Возможные типы каналов поступления обращения в систему.
	/// </summary>
	public enum ChannelTypes
    {
        Unknown = 0,

        // Почтовый канал поступления обращения.
        Exchange = 1,

        // Поступление по факсу.
        Fax = 2,

        // Из системы CRM.
        Crm = 3,

        // Посредством голосового обращения.
        Voice = 4
    }
}
