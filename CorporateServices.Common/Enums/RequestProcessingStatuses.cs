namespace CorporateServices.Common.Enums
{
    /// <summary>
	/// Статусы обращения (RequestData.Status) - сквозная нумерация
	/// Стэйты являются основными этапами (жизненные вехи), статусы - промежуточные этапы
	/// </summary>
	public enum RequestProcessingStatuses : short
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Ожидание отправки на распознавание
        /// </summary>
        WaitSendingAttachesToRecognition = 1,

        /// <summary>
        /// Отправка вложений на распознавание
        /// </summary>
        SendAttachesToRecognition = 2,

        /// <summary>
        /// Вложения отправлены на распознавание
        /// </summary>
        AttachesAreSentToRecognition = 3,

        /// <summary>
        /// Ожидание получения результатов распознавания
        /// </summary>
        WaitRecognitionResult = 4,

        /// <summary>
        /// Получение результатов распознавания
        /// </summary>
        GetRecognitionResults = 5,

        /// <summary>
        /// Обработано
        /// </summary>
        ClosedAsProcessed = 6,

        /// <summary>
        /// Спам
        /// </summary>
        ClosedAsSpam = 7,

        /// <summary>
        /// Дубль
        /// </summary>
        ClosedAsDublicate = 8,

        /// <summary>
        /// Нет ответа от клиента
        /// </summary>
        ClosedAsNoAnswerFromClient = 9,

        /// <summary>
        /// Дочернее
        /// </summary>
        ClosedAsChild = 10,

        /// <summary>
        /// Передано в другое подразделение
        /// </summary>
        ClosedAsToOtherDivision = 11,

        /// <summary>
        /// Ожидает ответа от клиента
        /// </summary>
        WaitingClientAnswer = 12,

        /// <summary>
        /// Получен ответ от клиента
        /// </summary>
        ClientAnswerReceived = 13,

        /// <summary>
        /// Ожидает назначения на оператора
        /// </summary>
        WaitingAssigningToOperator = 14,

        /// <summary>
        /// Назначено на оператора
        /// </summary>
        AssignedToOperator = 15,

        /// <summary>
        /// В работе у оператора
        /// </summary>
        UnderOperatorProcessing = 16,

        /// <summary>
        /// Отложено (Голос)
        /// </summary>
        PausedVoice = 17,

        /// <summary>
        /// Результаты распознавания получены
        /// </summary>
        RecognitionResultsReceived = 18,

        /// <summary>
        /// Назначено на супервизора
        /// </summary>
        AssignedToSupervisor = 19,

        /// <summary>
        /// Ожидание запроса в биллинг
        /// </summary>
        BillingWait = 25,

        /// <summary>
        /// Получение результатов из биллинга
        /// </summary>
        BillingDataGaining = 26,

        /// <summary>
        /// Результаты получены
        /// </summary>
        BillingDataGainingCompleted = 27,

        /// <summary>
        /// Результаты не получены
        /// </summary>
        BillingDataGainingFailed = 28,

        /// <summary>
        /// Ожидание ответов филиалов
        /// </summary>
        ChildRequestsAwaiting = 29,

        /// <summary>
        /// Новое (Голос)
        /// </summary>
        CreatedAsVoice = 30,
    }
}
