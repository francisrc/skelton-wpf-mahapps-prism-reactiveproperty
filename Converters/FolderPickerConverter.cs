using Microsoft.WindowsAPICodePack.Dialogs;
using Reactive.Bindings.Interactivity;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace Skelton.WpfMahAppsPrismReactiveProperty.Converters
{
    class FolderPickerConverter : ReactiveConverter<EventArgs, string>
    {
        protected override IObservable<string> OnConvert(IObservable<EventArgs> source)
        {
            return source
                .Select(_ => new CommonOpenFileDialog())
                .Do(x =>
                {
                    x.IsFolderPicker = true;
                    x.EnsureReadOnly = false;
                    x.AllowNonFileSystemItems = false;
                })
                .Where(x => x.ShowDialog() == CommonFileDialogResult.Ok)
                .Select(x => x.FileName);
        }
    }
}
