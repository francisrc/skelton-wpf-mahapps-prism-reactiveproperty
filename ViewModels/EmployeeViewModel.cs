using Skelton.WpfMahAppsPrismReactiveProperty.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace Skelton.WpfMahAppsPrismReactiveProperty.ViewModels
{
    class EmployeeViewModel
    {
        public ReactiveProperty<string> Name { get; private set; } = new ReactiveProperty<string>("鉄骨");
        public EmployeeViewModel(Employee model)
        {
            Name = ReactiveProperty.FromObject(model, x => x.Name, ignoreValidationErrorValue: true);
        }
    }
}
