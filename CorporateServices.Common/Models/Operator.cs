using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace CorporateServices.Common.Models
{
    public class Operator : NotificationObject, IEquatable<Operator>
    {
        private BaseRequestCard _currentRequest;
        private string _name;
        private string _login;
        private string _statusName;
        private string _statusCode;
        private TimeSpan? _timeInWork;
        private DateTime _statusUpdateTime;
        private DateTime? _statusValidUntil;
        private Guid _id;
        private TimeSpan? _timeInStatus;

        public BaseRequestCard CurrentRequest
        {
            get { return _currentRequest; }
            set
            {
                if (Equals(value, _currentRequest)) return;
                _currentRequest = value;
                RaisePropertyChanged("CurrentRequest");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                if (value == _login) return;
                _login = value;
                RaisePropertyChanged("Login");
            }
        }

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

        public string StatusCode
        {
            get { return _statusCode; }
            set
            {
                if (value == _statusCode) return;
                _statusCode = value;
                RaisePropertyChanged("StatusCode");
            }
        }

        public TimeSpan? TimeInWork
        {
            get { return _timeInWork; }
            set
            {
                if (value.Equals(_timeInWork)) return;
                _timeInWork = value;
                RaisePropertyChanged("TimeInWork");
            }
        }

        public TimeSpan? TimeInStatus
        {
            get { return _timeInStatus; }
            set
            {
                if (value.Equals(_timeInStatus)) return;
                _timeInStatus = value;
                RaisePropertyChanged("TimeInStatus");
            }
        }

        public DateTime StatusUpdateTime
        {
            get { return _statusUpdateTime; }
            set
            {
                if (value.Equals(_statusUpdateTime)) return;
                _statusUpdateTime = value;
                RaisePropertyChanged("StatusUpdateTime");
            }
        }

        public DateTime? StatusValidUntil
        {
            get { return _statusValidUntil; }
            set
            {
                if (value.Equals(_statusValidUntil)) return;
                _statusValidUntil = value;
                RaisePropertyChanged("StatusValidUntil");
            }
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (value.Equals(_id)) return;
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public bool Equals(Operator other)
        {
            return other != null && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Operator;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
