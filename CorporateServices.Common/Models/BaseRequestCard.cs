using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CorporateServices.Common.Enums;
using CorporateServices.Common.Helpers;
using CorporateServices.Recognition.Common;
using Microsoft.Practices.Prism.ViewModel;
using RequestPresentation.Common;

namespace CorporateServices.Common.Models
{
    /// <summary>
    /// Класс базового обращения
    /// </summary>
    //	TODO: вообще-то, это скорее ViewModel, а не Model. А Model для этого ViewModel - RequestData. Переделать!
    public abstract class BaseRequestCard : NotificationObject, IComparable<BaseRequestCard>, IEquatable<BaseRequestCard>
    {
        #region Defs

        private string _description;
        private string _accountNumber;
        private string _contactName;
        private DateTime _createDate;
        private string _topicName;
        private long _requestId;
        private string _filial;
        private IList<Attachment> _attachments;
        private bool _isAssigned;
        private TimeSpan _lifeTime;
        private string _statusModifiedBy;
        private string _originator;
        private string _redirectionReason;
        private DateTime _timeLastStateChanged;
        private Guid? _executorId;
        private string _source;

        private Operator _assignedToOperator;
        private short _priority;
        private RequestMilestone _requestMilestone;
        private VisualRecognitionSummaryStates _visualRecognitionSummaryState;
        private bool _operatorIsTerminating;
        private bool _isBusy;
        private RequestType _requestType;

        #endregion

        #region Protected & Interfaces impl

        public int CompareTo(BaseRequestCard other)
        {
            return RequestId.CompareTo(other.RequestId);
        }

        public bool Equals(BaseRequestCard other)
        {
            return RequestId == other.RequestId;
        }

        #endregion

        #region Publics

        /// <summary>
        /// Версия обращения
        /// </summary>
        public long RequestVersion { get; set; }

        /// <summary>
        /// Лицевой счет. Автоматически после идентификации клиента в АРМ и связывания идентифицированного клиента с Обращением.
        /// </summary>
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (value == _accountNumber) return;
                _accountNumber = value;
                RaisePropertyChanged("AccountNumber");
            }
        }

        /// <summary>
        /// Имя клиента. После идентификации клиента в АРМ и связывания идентифицированного клиента с Обращением.
        /// </summary>
        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (value == _contactName) return;
                _contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        /// <summary>
        /// Филиал
        /// </summary>
        public string Filial
        {
            get { return _filial; }
            set
            {
                if (value == _filial) return;
                _filial = value;
                RaisePropertyChanged("Filial");
            }
        }

        /// <summary>
        /// Дата и время создания (атрибут – INQUIRY.CREATE_DATE)
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                if (value.Equals(_createDate)) return;
                _createDate = value;
                RaisePropertyChanged("CreateDate");
            }
        }

        /// <summary>
        /// Текст Обращения (атрибут – INQUIRY.DESCRIPTION)
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Тип канала
        /// </summary>
        public abstract ChannelTypes ChannelType { get; }

        /// <summary>
        /// Тема (атрибут – INQUIRY.TOPIC.FULL_NAME)
        /// </summary>
        public string TopicName
        {
            get { return _topicName; }
            set
            {
                if (value == _topicName) return;
                _topicName = value;
                RaisePropertyChanged("TopicName");
            }
        }

        /// <summary>
        /// Вложения
        /// </summary>
        public IList<Attachment> Attachments
        {
            get { return _attachments; }
            set
            {
                if (Equals(value, _attachments)) return;
                _attachments = value;
                RaisePropertyChanged("Attachments");
            }
        }

        /// <summary>
        /// Внутренний номер
        /// </summary>
        public long RequestId
        {
            get { return _requestId; }
            set
            {
                if (value == _requestId) return;
                _requestId = value;
                RaisePropertyChanged("RequestId");
            }
        }

        /// <summary>
        /// Назначено супервизором
        /// </summary>
        public bool IsAssigned
        {
            get { return _isAssigned; }
            set
            {
                if (value.Equals(_isAssigned)) return;
                _isAssigned = value;
                RaisePropertyChanged("IsAssigned");
            }
        }

        /// <summary>
        /// Отправитель ОБРАЩЕНИЯ (например, кто завел обращение в CRM)
        /// </summary>
        public string Originator
        {
            get { return _originator; }
            set
            {
                if (value == _originator) return;
                _originator = value;
                RaisePropertyChanged("Originator");
            }
        }

        /// <summary>
        /// Получатель ОБРАЩЕНИЯ (куда пришло обращение, например, для CRM - название очереди)
        /// </summary>
        public string Source
        {
            get { return _source; }
            set
            {
                if (value == _source) return;
                _source = value;
                RaisePropertyChanged("Source");
            }
        }

        /// <summary>
        /// Время жизни обращеиня (разница между текущим врвременем и CreateDate с учетом временной зоны)
        /// </summary>
        public TimeSpan LifeTime
        {
            get { return _lifeTime; }
            set
            {
                if (value.Equals(_lifeTime)) return;
                _lifeTime = value;
                RaisePropertyChanged("LifeTime");
            }
        }


        /// <summary>
        /// Время последнего изменения обращения
        /// </summary>
        public DateTime TimeLastStateChanged
        {
            get { return _timeLastStateChanged; }
            set
            {
                if (value.Equals(_timeLastStateChanged)) return;
                _timeLastStateChanged = value;
                RaisePropertyChanged("TimeLastStateChanged");
            }
        }

        /// <summary>
        /// Кем изменен RequestData.ExecutorId
        /// </summary>
        public string StatusModifiedBy
        {
            get { return _statusModifiedBy; }
            set
            {
                if (value == _statusModifiedBy) return;
                _statusModifiedBy = value;
                RaisePropertyChanged("StatusModifiedBy");
            }
        }

        /// <summary>
        /// Причина из кастомных атрибутов (пока нет)
        /// </summary>
        public string RedirectionReason
        {
            get { return _redirectionReason; }
            set
            {
                if (value == _redirectionReason) return;
                _redirectionReason = value;
                RaisePropertyChanged("RedirectionReason");
            }
        }

        /// <summary>
        /// Идентификатор исполнителя
        /// </summary>
        public Guid? ExecutorId
        {
            get { return _executorId; }
            set
            {
                if (value.Equals(_executorId)) return;
                _executorId = value;
                RaisePropertyChanged("ExecutorId");
            }
        }

        #region ChangeableObject Block

        /// <summary>
        /// Назначено (RequestData.AssignedToId)
        /// </summary>
        public Operator AssignedToOperator
        {
            get
            {
                return _assignedToOperator;
            }
            set
            {
                if (value == _assignedToOperator) return;
                _assignedToOperator = value;
                RaisePropertyChanged("AssignedToOperator");
            }
        }

        /// <summary>
        /// Приоритет
        /// </summary>
        public short Priority
        {
            get { return _priority; }
            set
            {
                if (value == _priority) return;
                _priority = value;
                RaisePropertyChanged("Priority");
            }
        }

        /// <summary>
        /// Этап обработки обращения
        /// </summary>
        public RequestMilestone RequestMilestone
        {
            get { return _requestMilestone; }
            set
            {
                if (value == _requestMilestone) return;
                _requestMilestone = value;
                RaisePropertyChanged("RequestMilestone");
            }
        }

        /// <summary>
        /// Итоговый статус распознавания
        /// </summary>
        public VisualRecognitionSummaryStates VisualRecognitionSummaryState
        {
            get { return _visualRecognitionSummaryState; }
            set
            {
                if (value.Equals(_visualRecognitionSummaryState)) return;
                _visualRecognitionSummaryState = value;
                RaisePropertyChanged("VisualRecognitionSummaryState");
            }
        }

        public bool OperatorIsTerminating
        {
            get { return _operatorIsTerminating; }
            set
            {
                if (value.Equals(_operatorIsTerminating)) return;
                _operatorIsTerminating = value;
                RaisePropertyChanged("OperatorIsTerminating");
            }
        }

        public RequestData RequestData { get; set; }

        #endregion

        #endregion

        #region Иерархия

        private BaseRequestCard _parent;
        private readonly ObservableCollection<BaseRequestCard> _children = new ObservableCollection<BaseRequestCard>();

        public BaseRequestCard Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != null)
                    _parent._children.Remove(this);
                _parent = value;
                if (value != null)
                    SmartDispatcher.InvokeAsync(() => value._children.Add(this));
                RaisePropertyChanged("Parent");
            }
        }

        public IEnumerable<BaseRequestCard> Children
        {
            get { return _children; }
        }

        /// <summary>
        /// Нужно для индикации загрузки дочерних обращений.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value.Equals(_isBusy)) return;
                _isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        public RequestType RequestType
        {
            get { return _requestType; }
            set
            {
                if (value == _requestType) return;
                _requestType = value;
                RaisePropertyChanged("RequestType");
            }
        }

        #endregion

        protected override void RaisePropertyChanged(string propertyName)
        {
            SmartDispatcher.InvokeAsync(() => base.RaisePropertyChanged(propertyName));
        }
    }
}
