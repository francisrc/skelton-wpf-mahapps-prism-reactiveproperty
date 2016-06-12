using Skelton.WpfMahAppsPrismReactiveProperty.Models;
using Prism.Interactivity.InteractionRequest;
using Reactive.Bindings;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Skelton.WpfMahAppsPrismReactiveProperty.ViewModels
{
    class MainWindowViewModel : IDisposable
    {
        static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReactiveCollection<CompanyViewModel> Companies { get; }

        public ReactiveCommand<string> SelectFileCommand { get; } = new ReactiveCommand<string>();
        public ReadOnlyReactiveProperty<string> SelectedFilename { get; }

        public ReactiveCommand<string> StartCommand { get; }

        public InteractionRequest<Confirmation> ConfirmationRequest { get; } = new InteractionRequest<Confirmation>();
        public InteractionRequest<Notification> NotificationRequest { get; } = new InteractionRequest<Notification>();

        public MainWindowViewModel()
        {
            Logger.Info("Initializing...");

            // DB Context (SQLite)
            var context = new MainDbContext();

            // Create ViewModel collection from the models
            Companies = context.Companies
                .ToObservable()
                .Select(x => new CompanyViewModel(x))
                .ToReactiveCollection();
            // SelectFileCommand is fired from click event of button through EventToReactiveCommand.
            // SelectedFilename will be set after a file selected from OpenFileDialog through OpenFileDialogConverter.
            SelectedFilename = SelectFileCommand
                .Select(filename => filename)
                .ToReadOnlyReactiveProperty();
            // ReactiveCommand (can execute when SelectedFilename is set)
            StartCommand = SelectedFilename.Select(x => !string.IsNullOrWhiteSpace(x)).ToReactiveCommand<string>();
            StartCommand.Subscribe(async _ =>
            {
                var res = await ConfirmationRequest.RaiseAsync(new Confirmation { Title = "Demo", Content = "Are you sure?" });
                if (res.Confirmed)
                {
                    await NotificationRequest.RaiseAsync(new Notification { Title = "Demo", Content = "Done!" });
                }
            });
            Logger.Info("Initialized.");
        }

        public void Dispose()
        {
            Logger.Info("Disposing...");
            // Something to do
            Logger.Info("Disposed.");
        }
    }
}
