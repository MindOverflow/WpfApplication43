using CorporateServices.Common.Enums;

namespace CorporateServices.Common.Models
{
    public class CRMRequestCard : BaseRequestCard
    {
        private string _contactSiteName;
        private string _inquiryId;
        private string _statusName;
        private string _queueName;
        private string _registratorName;
        private string _initiatorName;
        private string _contactPerson;
        private string _contactPhone;
        private string _contactEmail;
        private string _crmContactName;
        private string _crmAccountNumber;

        public override ChannelTypes ChannelType
        {
            get { return ChannelTypes.Crm; }
        }

        /// <summary>
        /// Место контакта (атрибут – CONTACT_SITE.FULL_NAME)
        /// </summary>
        public string ContactSiteName
        {
            get { return _contactSiteName; }
            set
            {
                if (value == _contactSiteName) return;
                _contactSiteName = value;
                RaisePropertyChanged("ContactSiteName");
            }
        }

        /// <summary>
        /// Идентификатор обращения (атрибут – INQUIRY.ID)
        /// </summary>
        public string InquiryId
        {
            get { return _inquiryId; }
            set
            {
                if (value == _inquiryId) return;
                _inquiryId = value;
                RaisePropertyChanged("InquiryId");
            }
        }

        /// <summary>
        /// Статус обращения (атрибут – INQUIRY.CURRENT_STATE.STATUS.NAME)
        /// </summary>
        public string StatusName
        {
            get { return _statusName; }
            set
            {
                if (value == _statusName) return;
                _statusName = value;
                RaisePropertyChanged("StatusName");
            }
        }

        /// <summary>
        /// Наименование очереди (атрибут – INQUIRY.CURRENT_STATE.STATUS.QUEUE.FULL_NAME)
        /// </summary>
        public string QueueName
        {
            get { return _queueName; }
            set
            {
                if (value == _queueName) return;
                _queueName = value;
                RaisePropertyChanged("QueueName");
            }
        }

        /// <summary>
        /// Номер лицевого счета клиента (атрибут – CONTACT. CUSTOMER.ACCOUNT_NUMBER)
        /// </summary>
        public string CRMAccountNumber
        {
            get { return _crmAccountNumber; }
            set
            {
                if (value == _crmAccountNumber) return;
                _crmAccountNumber = value;
                RaisePropertyChanged("CRMAccountNumber");
            }
        }

        /// <summary>
        /// Оператор, зарегистрировавший обращение (атрибут – INQUIRY.SUBMITTER.FULL_NAME)
        /// </summary>
        public string RegistratorName
        {
            get { return _registratorName; }
            set
            {
                if (value == _registratorName) return;
                _registratorName = value;
                RaisePropertyChanged("RegistratorName");
            }
        }

        /// <summary>
        /// Оператор, передавший обращение в данную очередь (атрибут – INQUIRY_HISTORY.OPERATOR_NAME)
        /// </summary>
        public string InitiatorName
        {
            get { return _initiatorName; }
            set
            {
                if (value == _initiatorName) return;
                _initiatorName = value;
                RaisePropertyChanged("InitiatorName");
            }
        }

        /// <summary>
        /// Имя клиента (атрибут – CONTACT.NAME)
        /// </summary>
        public string CRMContactName
        {
            get { return _crmContactName; }
            set
            {
                if (value == _crmContactName) return;
                _crmContactName = value;
                RaisePropertyChanged("CRMContactName");
            }
        }

        /// <summary>
        /// Контактное лицо (атрибут – CONTACT.CONTACT_PERSON)
        /// </summary>
        public string ContactPerson
        {
            get { return _contactPerson; }
            set
            {
                if (value == _contactPerson) return;
                _contactPerson = value;
                RaisePropertyChanged("ContactPerson");
            }
        }

        /// <summary>
        /// Контактный номер телефона (атрибут – INQUIRY.CUSTOM_ATTRS.CUSTOM_ATTR.NAME=Контактный номер Абонента)
        /// </summary>
        public string ContactPhone
        {
            get { return _contactPhone; }
            set
            {
                if (value == _contactPhone) return;
                _contactPhone = value;
                RaisePropertyChanged("ContactPhone");
            }
        }

        /// <summary>
        /// Контактный Email (атрибут – INQUIRY.CUSTOM_ATTRS.CUSTOM_ATTR.NAME=Укажите E-mail адрес, на который требуется ответ)
        /// </summary>
        public string ContactEmail
        {
            get { return _contactEmail; }
            set
            {
                if (value == _contactEmail) return;
                _contactEmail = value;
                RaisePropertyChanged("ContactEmail");
            }
        }
    }
}
