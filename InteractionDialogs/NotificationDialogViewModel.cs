using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;

namespace Skelton.WpfMahAppsPrismReactiveProperty.InteractionDialogs
{
    class NotificationDialogViewModel : BindableBase, IInteractionRequestAware
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

        public NotificationDialogViewModel()
        {
            OKCommand = new DelegateCommand(() =>
            {
                FinishInteraction();
            }, () => true);
            CancelCommand = new DelegateCommand(() =>
            {
                FinishInteraction();
            }, () => true);
        }
    }
}
