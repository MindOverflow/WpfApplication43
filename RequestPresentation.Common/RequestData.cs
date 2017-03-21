using System;

namespace RequestPresentation.Common
{
    public class RequestData
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Версия
        /// </summary>
        public long Version { get; set; }

        /// <summary>
        /// Идентификатор обращения во внешней системе
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Время создания обращения (НЕ регистрации в системе CRPM, а именно создания - это определяет тот, кто регистрирует) (в UTC)
        /// <remarks>Например, это может быть время регистрации обращения в CRM, время получения письма, или его отправки, время звонка и т.п.</remarks>
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Время регистрации обращения в системе CRPM (в UTC)
        /// </summary>
        public DateTime TimeRegistered { get; set; }

        /// <summary>
        /// Время последнего изменения статуса (в UTC)
        /// </summary>
        public DateTime TimeLastStateChanged { get; set; }

        /// <summary>
        /// Время закрытия обращения в системе CRPM (перехода в терминальный статус) (в UTC)
        /// </summary>
        public DateTime? TimeClosed { get; set; }

        /// <summary>
        /// Тема
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание (тело)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Приоритет обращения
        /// </summary>
        public short Priority { get; set; }

        /// <summary>
        /// Последний исполнитель обращения
        /// </summary>
        public Guid? ExecutorId { get; set; }

        /// <summary>
        /// Этап обработки обращения
        /// </summary>
        public short? State { get; set; }

        /// <summary>
        /// Статус обработки обращения
        /// </summary>
        public short? Status { get; set; }

        /// <summary>
        /// Идентификатор потока, в который поступило обращение
        /// </summary>
        public short? StreamId { get; set; }

        /// <summary>
        /// Идентификатор очереди, в которой находится обращение
        /// </summary>
        public short? QueueId { get; set; }

        /// <summary>
        /// Идентификатор кампании, под которую попало обращение
        /// </summary>
        public short? CampaignId { get; set; }

        /// <summary>
        /// Идентификатор схемы, по которой выполняется обработка обращения
        /// </summary>
        public short? SchemaId { get; set; }

        /// <summary>
        /// Филиал
        /// <remarks>ВНИМАНИЕ: Этот атрибут будет упразднён. Не ставлю obsolete, потому что это может привести к неправильной де/сериализации (было такое как-то, правда, с XmlSerializaer'ом)</remarks>
        /// </summary>
        public Guid? BranchId { get; set; }

        /// <summary>
        /// Канал обращения
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Текст обращения без разметки
        /// </summary>
        public string PlainText { get; set; }

        /// <summary>
        /// Источник обращения
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Возбудитель :)
        /// </summary>
        public string Originator { get; set; }

        /// <summary>
        /// Идентификатор родительского обращения
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// Список идентификаторов дочерних обращений
        /// </summary>
        public long[] ChildRequests { get; set; }

        /// <summary>
        /// Идентификатор обращениея относительно которого данное обращение считается повторным 
        /// </summary>
        public long? RepeatedRequestId { get; set; }
    }
}
