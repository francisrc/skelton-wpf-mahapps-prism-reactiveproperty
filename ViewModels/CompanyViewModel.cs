using Skelton.WpfMahAppsPrismReactiveProperty.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace Skelton.WpfMahAppsPrismReactiveProperty.ViewModels
{
    class CompanyViewModel
    {
        public ReactiveProperty<string> Name { get; }
        public ReactiveCollection<EmployeeViewModel> Employees { get; }
        public CompanyViewModel(Company model)
        {
            Name = ReactiveProperty.FromObject(model, x => x.Name, ignoreValidationErrorValue: true);
            Employees = model.Employees
               .ToObservable()
               .Select(x => new EmployeeViewModel(x))
               .ToReactiveCollection();
        }
    }
}
