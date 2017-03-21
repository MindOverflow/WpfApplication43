using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateServices.Common.Enums;
using CorporateServices.Common.Helpers;
using Microsoft.Practices.Prism.ViewModel;

namespace CorporateServices.Common.Models
{
    /// <summary>
	/// Этап обработки обращения
	/// </summary>
	public class RequestMilestone : NotificationObject
    {
        private short? _stateId;
        private short? _statusId;
        private string _statusTitle;
        private string _stateTitle;

        public short? StateId
        {
            get { return _stateId; }
            set
            {
                if (value == _stateId) return;
                _stateId = value;
                RaisePropertyChanged("StateId");
            }
        }

        public short? StatusId
        {
            get { return _statusId; }
            set
            {
                if (value == _statusId) return;
                _statusId = value;
                RaisePropertyChanged("StatusId");
            }
        }

        public string StateTitle
        {
            get { return _stateTitle; }
            set
            {
                if (value == _stateTitle) return;
                _stateTitle = value;
                RaisePropertyChanged("StateTitle");
                RaisePropertyChanged("FullTitle");
                RaisePropertyChanged("BriefTitle");
            }
        }

        public string StatusTitle
        {
            get { return _statusTitle; }
            set
            {
                if (value == _statusTitle) return;
                _statusTitle = value;
                RaisePropertyChanged("StatusTitle");
                RaisePropertyChanged("FullTitle");
                RaisePropertyChanged("BriefTitle");
            }
        }

        public string FullTitle
        {
            get
            {
                return string.IsNullOrEmpty(StatusTitle) && string.IsNullOrEmpty(StateTitle)
                    ? string.Empty
                    : string.Join("/", StateTitle, StatusTitle).Trim('/');
            }
        }

        public string BriefTitle
        {
            get
            {
                return !StatusTitle.IsNullOrWhiteSpace()
                    ? StatusTitle
                    : StateTitle;
            }
        }

        public RequestProcessingStatuses RequestProcessingStatus
        {
            get
            {
                return StatusId.HasValue && Enum.IsDefined(typeof(RequestProcessingStatuses), StatusId.Value) ?
                    (RequestProcessingStatuses)StatusId.Value : RequestProcessingStatuses.Unknown;
            }
        }
    }
}
