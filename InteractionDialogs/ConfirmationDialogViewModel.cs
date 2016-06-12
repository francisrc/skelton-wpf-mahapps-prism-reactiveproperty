using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skelton.WpfMahAppsPrismReactiveProperty.InteractionDialogs
{
    class ConfirmationDialogViewModel : BindableBase, IInteractionRequestAware
    {
        // IInteractionRequestAware
        public Action FinishInteraction { get; set; }
        private INotification _Notification;
        public INotification Notification
        {
            get { return _Notification; }
            set { SetProperty(ref _Notification, value); }
        }

        public DelegateCommand OKCommand { get; }
        public DelegateCommand CancelCommand { get; }

        public ConfirmationDialogViewModel()
        {
            OKCommand = new DelegateCommand(() =>
            {
                (Notification as Confirmation).Confirmed = true;
                FinishInteraction();
            }, () => true);
            CancelCommand = new DelegateCommand(() =>
            {
                FinishInteraction();
            }, () => true);
        }
    }
}
