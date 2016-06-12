using Reactive.Bindings.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using Reactive.Bindings;
using System.Reactive.Linq;
using Microsoft.Win32;

namespace Skelton.WpfMahAppsPrismReactiveProperty.Converters
{
    class OpenFileDialogConverter : ReactiveConverter<EventArgs, string>
    {
        protected override IObservable<string> OnConvert(IObservable<EventArgs> source)
        {
            return source
                .Select(_ => new OpenFileDialog())
                .Do(x => x.Filter = "*.*|*.*")
                .Where(x => x.ShowDialog() == true) // Show dialog
                .Select(x => x.FileName); // convert to string
        }
    }
}
